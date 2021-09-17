import { Component } from "react";
import '../../../assets/css/Produto.css'
import axios from "axios";

class ModalCadastro extends Component{
    constructor(props){
      super(props);
      this.state = {
        ListaProduto : [],
        idTipoProduto: 0,
        nome: '',
        quantidade : 0,
        descricao : '',
        imagem : '',
        preco : 0,
        validade : Date
      }
    }

//---------------------------------------------------------------------------

listarProduto = () =>
{
    console.log('ta funfando confia!!')

    fetch('http://localhost:5000/api/Produtos') 

    .then(resposta => resposta.json())

    .then(dados => this.setState({ListaProduto : dados}))

    .catch(erro => console.log(erro))
}

//---------------------------------------------------------------------------


CadastrarProduto = async (event) => {

    event.preventDefault();

    await axios.post('http://localhost:5000/api/Produtos', {
        idTipoProduto : this.state.idTipoProduto,
        nome : this.state.nome,
        quantidade : this.state.quantidade,
        descricao : this.state.descricao,
        imagem : this.state.imagem,
        preco : this.state.preco,
        validade : this.state.validade
      })
      .then(resposta => {
          if(resposta.status === 201) {
              console.log("criado")

              this.setState({
                idTipoProduto: '',
                nome: '',
                quantidade : '',
                descricao : '',
                imagem : '',
                preco : '',
                validade : ''
              })
          }
      })

      .catch(erro => console.log(erro))
  }

  //---------------------------------------------------------------------------

  funcaoMudaState = (campo) => {
    this.setState({[campo.target.name] : campo.target.value})
  }

  //---------------------------------------------------------------------------

  componentDidMount(){
    this.CadastrarProduto();
    this.listarProduto();
  }

//---------------------------------------------------------------------------

render(){
  return(
    <form onSubmit={this.CadastrarProduto} class="areaCadastroEquip">
      <div class="contentCadastroEquipamento">
        <div class="contentInput dis">

        <div class="contentInput dis">
            <div class="tituloCadastroBig">
                <p> TipoProduto </p>
            </div>
              <select name="IdTipoProduto" value={this.state.idTipoProduto} class="selectCadastros" id="" onChange={this.funcaoMudaState}>
                  <option value="0">Selecione um tipo de produto</option>
                  {
                      this.state.ListaProduto.map((prd) => {
                          return(
                          <option value={prd.idTipoProduto}>{prd.tituloTipoProduto}</option>
                          )
                      })
                  }
              </select>
          </div>

            <div class="tituloCadastroBig">
              <p> Nome </p>
            </div>
              <input class="inputsCadastros" name='Nome' value={this.state.nome} type="text" placeholder="Digite o nome do Produto" onChange={this.funcaoMudaState}/>


              <div class="tituloCadastroBig">
              <p> Quantidade </p>
            </div>
              <input class="inputsCadastros" name='Nome' value={this.state.quantidade} type="number" placeholder="Digite a quantidade de produtos" onChange={this.funcaoMudaState}/>
              
              <div class="tituloCadastroBig">
              <p> Descrição </p>
            </div>
              <input class="inputsCadastros" name='Descrição' value={this.state.descricao} type="text" placeholder="Digite a descrição do Produto" onChange={this.funcaoMudaState}/>

              <div class="tituloCadastroBig">
              <p> Preço </p>
            </div>
              <input class="inputsCadastros" name='Preco' value={this.state.preco} type="number" placeholder="Digite o preço do produto" onChange={this.funcaoMudaState}/>

              <div class="tituloCadastroBig">
              <p> Validade </p>
            </div>
              <input class="inputsCadastros" name='Validade' value={this.state.validade} type="date" placeholder="Digite a validade produto" onChange={this.funcaoMudaState}/>

              <div class="tituloCadastroBig">
              <p> Validade </p>
            </div>
              <input class="inputsCadastros" name='Imagem' value={this.state.imagem} type="file" placeholder="insira a imagem do produto" onChange={this.funcaoMudaState}/>
        </div>
      </div>
    </form>
    )
  }
}
        
export default ModalCadastro;