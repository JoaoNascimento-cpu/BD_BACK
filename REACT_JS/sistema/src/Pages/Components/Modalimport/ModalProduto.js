import { Component } from "react";
import '../../../assets/css/Produto.css'

class ModalProdutos extends Component{
    constructor(props){
      super(props);
      this.state = {
        ListaProduto : [],
        idProdutoAlterado : 0,
        idProduto : 0,
        Nome : '',
        IdTipo : 0,
        imagem : '',
        Descrição : '',
        Preco : '',
        Qtd : 0,
        val : "2021-12-31T00:00:00"
      }
    }

//---------------------------------------------------------------------------

//LISTA_OS_PRODUTOS
listarProduto = () =>
{
    console.log('ta funfando confia!!')

    fetch('http://localhost:5000/api/Produtos') 

    .then(resposta => resposta.json())

    .then(dados => this.setState({ListaProduto : dados}))

    .catch(erro => console.log(erro))
}

//---------------------------------------------------------------------------

buscarProdutoPorId = (produto) => {
  this.setState({
    idProdutoAlterado : produto.idProduto,
    idTipoProduto : produto.IdTipo,
    nome : produto.Nome,
    quantidade : produto.Qtd,
    descricao : produto.Descrição,
    imagem : produto.imagem,
    preco : produto.Preco,
    validade : produto.val
  }, () => {
      console.log(
          'A consulta ' + produto.idProduto+ ' foi selecionado,',
          'agora o valor do state idConsultaAlterado é: ' + this.state.idProdutoAlterado,
          'e o valor do state id paciente é:' + this.state.idProduto
      );
  });
};
//---------------------------------------------------------------------------

CadastranovoProduto = (event) => {
//IGNOROU O COMPORTAMENTO PADRÃO DO NAVEGADOR
event.preventDefault();

if(this.state.idProdutoAlterado !== 0){   
    //CHAMA A API USANDO FETCH
    fetch('http://localhost:5000/api/Produtos/' + this.state.idProdutoAlterado, {

    //DEFINE O METODO DA REQUISIÇÃO COMO PUT
    method: 'PUT',

    //CONVERTE A RESPOSTA RECEBIDA EM JSON
    body : JSON.stringify ({idProduto : this.state.idProduto, nome : this.state.nome, idTipoProduto : this.state.idTipoProduto, quantidade : this.state.quantidade, imagem : this.state.imagem, preco : this.state.preco, validade : this.state.quantidade }),

    //DEFINE O CABEÇALHO DA REQUISIÇÃO
    Headers : {
        'Content-Type' : 'application/json'
    }
    })

    .then(resposta => {
        if(resposta.status === 204){
            console.log('Produto ' + this.state.idProdutoAlterado + ' atualizado')
        }
    })
    .then(this.listarProduto)
    .then(this.limparCampos)
}
else
{        
    //CHAMA A API USANDO FETCH
    fetch('http://localhost:5000/api/consultas', {
        
    //DEFINE O METODO DA REQUISIÇÃO COMO POST
    method : 'POST',
        
    //CONVERTE A RESPOSTA RECEBIDA EM JSON
    body : JSON.stringify ({nome : this.state.nome, idTipoProduto : this.state.idTipoProduto, quantidade : this.state.quantidade, imagem : this.state.imagem, preco : this.state.preco, validade : this.state.quantidade }),

    //DEFINE O CABEÇALHO DA REQUISIÇÃO
    headers : {
    "Content-Type" : "application/json"
    }
})
    .then(console.log('Produto Cadastrada'))
    .catch(erro => console.log(erro))
}
}

//---------------------------------------------------------------------------

excluirProduto = (produto) => {
  console.log('O produto ' + produto.idProduto + ' foi selecionado')

  //CHAMA A API PASSANDO O ID DO EVENTO SELECIONADO NA URL
  fetch('http://localhost:5000/api/Produtos/' + produto.idProduto, {

      //DEFINE O METODO DA REQUISIÇÃO
      method : 'DELETE'
  })

  .then(resposta => {
      if(resposta.status === 204){
          console.log('Produto' + produto.idProduto + 'foi excluido')
      }
  })

  .catch(erro => console.log(erro))

  .then(this.listarProduto)
}

//---------------------------------------------------------------------------

atualiazarDesejo = async (event) =>
{
  await this.setState({Produto : event.target.value})
}

//---------------------------------------------------------------------------

atualiazarTipoProduto = async (event) =>
{
  await this.setState({ IdTipo : event.target.value})
}

//---------------------------------------------------------------------------

atualiazarNome = async (event) =>
{
  await this.setState({ Nome : event.target.value })
}

//---------------------------------------------------------------------------

atualiazarDescricao = async (event) =>
{
  await this.setState({ Descrição : event.target.value })
}

//---------------------------------------------------------------------------


atualiazarQtd = async (event) =>
{
  await this.setState({ Qtd : event.target.value })
}

//---------------------------------------------------------------------------

atualiazarPreco = async (event) =>
{
  await this.setState({ Preco : event.target.value })
}

//---------------------------------------------------------------------------

atualiazarValid = async (event) =>
{
  await this.setState({ val : event.target.value })
}

//---------------------------------------------------------------------------

atualiazarImg = async (event) =>
{
  await this.setState({ imagem : event.target.file })
}

//---------------------------------------------------------------------------

componentDidMount(){
  this.listarProduto();
}

//---------------------------------------------------------------------------

render(){
  return(
      <div className='table'>
        {
        this.state.ListaProduto.map((dados)=>{
            return(
              <div className='a1'>
              <img src={dados.imagem}/>
              <p>{dados.imagem}</p>
              <p><b>IdProduto</b>  {dados.idProduto}</p>
              <p><b>Tipo Produto</b>  {dados.idTipoProduto}</p>
              <p><b>Nome:</b>  {dados.nome}</p>
              <p><b>Qtd:</b>  {dados.quantidade}</p>
              <p><b>Decrição:</b>  {dados.descricao}</p>
              <p><b>Preço:</b>  {dados.preco}</p>
              <p><b>Validade:</b>  {dados.validade}</p>
              <p>Ações: <button onClick={() => this.buscarProdutoPorId(dados)}>Editar</button> <button onClick={() => this.excluirProduto(dados)}>Excluir</button> </p>
              </div>
            )
        })
        }
      </div> 
    )
  }
}
        
export default ModalProdutos;