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