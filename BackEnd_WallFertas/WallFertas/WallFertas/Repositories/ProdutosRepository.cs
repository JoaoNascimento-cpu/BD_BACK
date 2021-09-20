using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using WallFertas.Contexts;
using WallFertas.Domains;
using WallFertas.Interfaces;

namespace WallFertas.Repositories
{
    public class ProdutosRepository : IProdutosRepository
    {
        WallFertas_Context ctx = new WallFertas_Context();
        public void Atualizar(int id, Produtos produtoAtualizado)
        {
            Produtos produtoBuscado = ctx.Produtos.Find(id);

            if (produtoBuscado != null)
            {
                produtoBuscado.Descricao = produtoAtualizado.Descricao;
            }

            ctx.Produtos.Update(produtoBuscado);
            ctx.SaveChanges();
        }

        public Produtos BuscarPorId(int id)
        {
            return ctx.Produtos.FirstOrDefault(i => i.IdProduto == id);
        }

        public void Cadastrar(Produtos novoProduto)
        {
            ctx.Add(novoProduto);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Produtos produtoBuscado = ctx.Produtos.Find(id);
            ctx.Produtos.Remove(produtoBuscado);
            ctx.SaveChanges();
        }

        public List<Produtos> Listar()
        {
            return ctx.Produtos.ToList();
        }

        public string UploadFoto(IFormFile arquivo, string savingFolder)
        {
            // se a "savingFolder" (pasta de salvamento) está vazia...
            if (savingFolder == null)
            {
                // mescla seu caminho com a pasta "Imagens"
                savingFolder = Path.Combine("Imagens");
            }

            // variavel "pathToSave" (caminho para salvar) será igual a mescla entre o caminho inicial da nossa aplicação + savingFolder
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), savingFolder);

            // caso a pasta estiver com mais que 10 imagens...
            if (savingFolder == "Imagens")
            {
                // será feito uma limpeza para que não tenha problema no desempenho
                // string array "fileEntries" (entradas de arquivo) pega os arquivos do "pathToSave" que é onde está as Imagens armazenadas
                string[] fileEntries = Directory.GetFiles(pathToSave);
                // se a quantidade de arquivos for maior ou igual a 50...
                if (fileEntries.Length >= 50)
                {
                    for (int i = 0; i < fileEntries.Length; i++)
                    {
                        // será deletado
                        File.Delete(fileEntries[i]);
                    }
                }
            }

            // se o tamanho do nome do arquivo (das Imagens, no caso) for maior q 3...
            if (arquivo.FileName.Length > 3)
            {
                // variavel "fileName" que converte o nome do arquivo para uma instância ContentDispositionHeaderValue, ou seja, troca o nome por um id, assim, não irá se repetir arquivos com mesmos nomes na pasta
                var fileName = ContentDispositionHeaderValue.Parse(arquivo.ContentDisposition).FileName.Trim('"');
                // variavel "fullPath" que pega o caminho completo dos arquivos, mesclando o caminho onde é salvo e os nomes dos arquivos
                var fullPath = Path.Combine(pathToSave, fileName);

                // aqui é onde o nome do arquivo é copiado para a pasta certa
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    // onde copia o arquivo
                    arquivo.CopyTo(stream);
                }

                // variavel "nomeArquivo" é igual ao nome do arquivo
                var nomeArquivo = arquivo.FileName;
                // variavel "extensao" é igual ao nome da extensão do arquivo
                string extensao = nomeArquivo.Split('.')[1].Trim();
                // string "nome" é igual a "Guid.NewGuid().ToString()" (esse Guid dará o novo nome para o arquivo, esse nome será um identificador único, um id) + a sua extensão
                string nome = Guid.NewGuid().ToString() + "." + extensao;
                // string "sourceFile" (arquivo de origem) onde será colocado o "modo" de como pesquisar esse arquivo: http://localhost:5000/ + FotosBackUp + / + foto
                string sourceFile = Path.Combine(Directory.GetCurrentDirectory(), savingFolder + "/" + arquivo.FileName);
                // string "source" que é igual: http://localhost:5000/ + Imagens + /
                string source = Path.Combine(Directory.GetCurrentDirectory(), savingFolder + "/");

                // classe FileInfo (que consegue mover, excluir, renomear, etc)
                FileInfo fotoInfo = new FileInfo(sourceFile);
                // após ter preparado todo o arquivo uploaded, ele é movido para a pasta com o seu nome alterado
                fotoInfo.MoveTo(source + nome);
                return nome;
            }
            // caso contrário...
            else
            {
                // retorna null
                return null;
            }
        }
    }
}
