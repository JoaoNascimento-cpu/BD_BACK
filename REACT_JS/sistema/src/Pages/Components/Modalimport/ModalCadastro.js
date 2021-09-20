import { Component } from "react";
import '../../../assets/css/Produto.css'

const url = "http://localhost:5000"
const uri = "../../assets/img/"
class ModalCadastro extends Component{
    constructor(props){
      super(props);
      this.state = {
        ListaProduto : [],
        idProduto : 0,
        idTipoProduto: 0,
        nome: '',
        quantidade : 0,
        descricao : '',
        imagem : '',
        preco : 0,
        validade : '2021-12-31T00:00:00',
      }
    }
//---------------------------------------------------------------------------

AtualizaIdTipo = async(event) => {
  await this.setState({idTipoProduto : event.target.value})
}

//---------------------------------------------------------------------------------------------------

AtualizaNome = async(event) => {
  await this.setState({nome : event.target.value})
}

//---------------------------------------------------------------------------------------------------

AtualizaQtd = async(event) => {
  await this.setState({quantidade : event.target.value})
}

//---------------------------------------------------------------------------------------------------

AtualizaDesc = async(event) => {
  await this.setState({descricao : event.target.value})
};

//---------------------------------------------------------------------------------------------------

AtualizaImg = async(event) => {
  await this.setState({imagem : event.target.value})
}
//---------------------------------------------------------------------------------------------------

AtualizaPreco = async(event) => {
  await this.setState({preco : event.target.value})
};

//---------------------------------------------------------------------------------------------------
AtualizaValid = async(event) => {
  await this.setState({validade : event.target.value})
};
//---------------------------------------------------------------------------------------------------
//<input placeholder="Insira a imagem" value = {this.state.imagem} onChange={this.atualiazarImg}type="file"></input>

cadastraProduto = (event) => {
  //IGNOROU O COMPORTAMENTO PADRÃO DO NAVEGADOR
  event.preventDefault();

  fetch('http://localhost:5000/api/Produtos', {
          
      //DEFINE O METODO DA REQUISIÇÃO COMO POST
      method : 'POST',
          
      //CONVERTE A RESPOSTA RECEBIDA EM JSON
      body : JSON.stringify ({
        idProduto : this.state.idProduto,
        nome : this.state.nome, 
        idTipoProduto : this.state.idTipoProduto, 
        imagem : this.state.imagem,        
        quantidade : this.state.quantidade,
        descricao : this.state.descricao, 
        preco : this.state.preco, 
        validade : this.state.validade }),
      
      //DEFINE O CABEÇALHO DA REQUISIÇÃO
      headers : {
      "Content-Type" : "application/json"
      }
  });
}

//---------------------------------------------------------------------------------------------------
limparCampos = () => {
  this.setState({
    idTipoProduto: '',
    nome: '',
    quantidade : '',
    descricao : '',
    imagem : '',
    preco : '',
    validade : '',
  })
}
//---------------------------------------------------------------------------------------------------

  logout = () => {
      localStorage.removeItem('wallfertas-chave-autenticacao')
  }
//---------------------------------------------------------------------------------------------------
render(){
  return(
    <section className="Cadastro">
                <a onClick={this.logout} href="/"><h3>Sair</h3></a>
                <h2>CADASTRO DE PRODUTO</h2>
                    <form onSubmit={this.cadastraProduto} className="formulario">
                <div>
                    <input value = {this.state.idTipoProduto} onChange={this.AtualizaIdTipo} type="number"></input>

                    <input placeholder="Digite o nome do produto" value = {this.state.nome} onChange={this.AtualizaNome}type="text"></input>

                    <input placeholder= "Digite a quantidade do produto" value = {this.state.quantidade} onChange={this.AtualizaQtd} type="text"></input>

                    <input placeholder="Digite a descricao" value = {this.state.descricao} onChange={this.AtualizaDesc} type="text"></input>

                    <input placeholder="Digite a descricao" id="file-id" name="imagem" value = {this.state.imagem} onChange={this.AtualizaImg} type="file"/>
                    <img src={this.state.imagem.split('\\')[2]} alt="feito"/>
                    

                    <input placeholder="Preço do produto" value = {this.state.preco} onChange={this.AtualizaPreco} type="number"></input>
                    
                    {
                        <button type='submit' disabled={this.state.idTipoProduto === '', this.state.descricao === '', this.state.imagem === '', this.state.nome === '', this.state.preco ==='', this.state.quantidade === '', this.state.validade === '' ? 'none' : ''}>Cadastrar</button>
                    }
                        <button onClick={this.limparCampos}>
                            Cancelar
                        </button>
                </div>
            </form> 
                </section>
    )
  }
}
export default ModalCadastro;