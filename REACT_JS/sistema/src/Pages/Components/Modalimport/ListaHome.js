import { Component } from "react";
import '../../../assets/css/Produto.css'




class ModalHome extends Component{
    constructor(props){
      super(props);
      this.state = {
        ListaProduto : [],
        Nome : '',
        IdTipo : 0,
        imagem : '',
        Descrição : '',
        Preco : '',
        Qtd : 0,
        val : Date
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

buscarProdutoId = (Produtos) => {
  this.setState({
    idProduto      :  Produtos.idProduto,
    ListaProduto   :  Produtos.nome,

  });
};

//---------------------------------------------------------------------------

deletaProduto = (Produtos) => {

  fetch('http://localhost:5000/api/Produtos/'+ Produtos.idProduto, {
    method : 'DELETE'
  })

  .catch(erro => console.log(erro))
}

//---------------------------------------------------------------------------

atualiazarDesejo = async (event) =>
{
  await this.setState({Produto : event.target.value})
}

atualiazarTipoProduto = async (event) =>
{
  await this.setState({ IdTipo : event.target.value})
}

atualiazarNome = async (event) =>
{
  await this.setState({ Nome : event.target.value })
}

atualiazarDescricao = async (event) =>
{
  await this.setState({ Descrição : event.target.value })
}

atualiazarQtd = async (event) =>
{
  await this.setState({ Qtd : event.target.value })
}

atualiazarPreco = async (event) =>
{
  await this.setState({ Preco : event.target.value })
}

atualiazarValid = async (event) =>
{
  await this.setState({ val : event.target.value })
}

atualiazarImg = async (event) =>
{
  await this.setState({ imagem : event.target.value })
}

componentDidMount(){
  this.listarProduto();
}
render(){
  return(
      <div className='table'>
        {
        this.state.ListaProduto.map((dados)=>{
            return(
              <div className='a1'>
              <p>{dados.nome}</p>
              <p>{dados.descricao}</p>
              <p>{dados.imagem}</p>
              <p>{dados.preco}</p>
              </div>
            )
        })
        }
      </div> 
    )
  }
}
        
export default ModalHome;