import { Component } from 'react';
import logo from '../../assets/img/WallFertas.png'
import pao from '../../assets/img/pao.jpeg'
import carne from '../../assets/img/Carne.jpeg'
import refri from '../../assets/img/refri.jpeg'
import frutas from '../../assets/img/frutas.jpeg'
import vegetais from '../../assets/img/vegetais.jpeg'
import arroz from '../../assets/img/arroz.jpg'
import peixe from '../../assets/img/peixe-assado-cerveja.jpg'
import frete from '../../assets/img/frente.jpeg'
import '../../assets/css/home.css';


class Produtos extends Component{
  constructor(props){
    super(props);
    this.state = {
      ListaProduto : [],
      Nome : '',
      Descrição : '',
      Preco : '',
    }
  }

  ListarProduto = () => {
    fetch('http://localhost:5000/api/Salas')

    .then(resposta => resposta.json())

    .then(dados => this.setState({ListaProduto : dados}))

    .catch((erro) => console.log(erro))

  }

  componentDidMount(){
    this.ListarProduto();
  }


  deslogar () {
    localStorage.removeItem('token-login')
  }

  render(){
    return(
        <div className='tudo'>
        <div class="Menu">
        <div class="logo">
        <img src={logo} alt="logo"/>
        </div>
        <div class="lista-menu">
            <ul>
                <li>Inicio</li>
                <li>História</li>
                <li>Contatos</li>
                <li><i class="fas fa-phone-square-alt"></i>(11)94002-8922</li>
                <li><i class="fas fa-user"></i></li>
                <li><i class="fas fa-shopping-cart"></i></li>
                <input type='text' placeholder="Pesquise um produto"/><i class="fas fa-search"></i>
            </ul>
        </div>
    </div>

<div className='prd'>
    <div class="imagens">
    <div class="Quadro1">
        <div>
        <img src={pao} alt="logo"/>
            <h2>Pães & Padarias</h2>
            <p>Os melhores produtos</p>
        </div>
    </div>
    <div class="Quadro1">
        <div>
        <img src={carne} alt="logo"/>
            <h2>Carnes</h2>
            <p>Os melhores produtos</p>
        </div>
    </div>
    <div class="Quadro1">
        <div>
        <img src={refri} alt="logo"/>
            <h2>Bebidas</h2>
            <p>Os melhores produtos</p>
        </div>
    </div>
    <div class="Quadro2">
        <div>
        <img src={frutas} alt="logo"/>
            <h2>Frutas</h2>
            <p>Frutas selecionadas</p>
            <h3>20% de Desconto</h3>
        </div>
    </div>
</div>
<div class="l2">
    <div class="Quadro3">
        <div>
        <img src={vegetais} alt="logo"/>
            <h2>Vegetais</h2>
            <p>Produtos Selecionados</p>
        </div>
    </div>
    <div class="Quadro3">
        <div>
        <img src={arroz} alt="logo"/>
            <h2>Arroz</h2>
            <p>Os melhores produtos</p>
        </div>
    </div>
    <div class="Quadro3">
        <div>
        <img src={peixe} alt="logo"/>
            <h2>Peixes</h2>
            <p>Os melhores Produtos</p>
        </div>
    </div>
</div>
<div>
    <div class="frete">
    <img src={frete} alt="logo"/>
        <h1>NAS COMPRAS ACIMA DE R$100,00</h1>
        <p>VÁLIDO PARA AS REGIÕES SUL E SUDESTE</p>
    </div>
</div>
    <div class="filter">
        <div class="q1">
            <h1>AÇUCAR</h1>
        </div>
        <div class="q1">
            <h1>ARROZ</h1>
        </div>
        <div class="q1">
            <h1>BEBIDAS</h1>
        </div>
        <div class="q1">
            <h1>PÃES</h1>
        </div>
        <div class="q1">
            <h1>OFERTAS</h1>
        </div>
    </div>
</div>
<div class="footer">
</div>
</div>
    )
  }
}

export default Produtos;