import { Component} from 'react';
import logo from '../../../assets/img/w2.png'

import '../../../assets/css/login.css'

class ModalUsuario  extends Component{
    constructor(props){
        super(props);
        this.state = {
            idTipoUsuario : 2,
            nome : '',
            email : '',
            senha : '',
        }
    }

    //---------------------------------------------------------------------------------------------------
    //ATUALIZA idTipoUsuario

    AtualizaIdTipoUsuario = async(event) => {
        await this.setState({idTipoUsuario : event.target.value})
    }

    //---------------------------------------------------------------------------------------------------
    //ATUALIZA EMAIL

    AtualizaEmail = async(event) => {
        await this.setState({email : event.target.value})
    }

    //---------------------------------------------------------------------------------------------------
    //ATUALIZA SENHA

    AtualizaSenha = async(event) => {
        await this.setState({senha : event.target.value})
    }

    //---------------------------------------------------------------------------------------------------
    //ATUALIZA A NOME

    AtualizaNome = async(event) => {
        await this.setState({nome : event.target.value})
    };

    //CADASTRA UM NOVA USUARIO

    cadastranovousuario = (event) => {
        //IGNOROU O COMPORTAMENTO PADRÃO DO NAVEGADOR
        event.preventDefault();

        fetch('http://localhost:5000/api/Usuarios', {
                
            //DEFINE O METODO DA REQUISIÇÃO COMO POST
            method : 'POST',
                
            //CONVERTE A RESPOSTA RECEBIDA EM JSON
            body : JSON.stringify ({idTipoUsuario : this.state.idTipoUsuario, email : this.state.email, senha : this.state.senha, nome : this.state.nome}),
            
            //DEFINE O CABEÇALHO DA REQUISIÇÃO
            headers : {
            "Content-Type" : "application/json"
            }
        });
    }

//---------------------------------------------------------------------------------------------------
    limparCampos = () => {
        this.setState({
            idTipoUsuario : 2,
            email : '',
            senha : '',
            nome : ''
        })
    }
//---------------------------------------------------------------------------------------------------
    render(){ 
        return(
            <main>
                <section>
                <img src={logo} alt="logo"/>
                    <form onSubmit={this.cadastranovousuario} className="areaLogin dis column">
                <div className="Cadastrar">
                    
                    <input placeholder="Digite o email do usuario" value = {this.state.email} onChange={this.AtualizaEmail}type="text" className="inputsLogin"></input>

                    <input placeholder="Digite a senha do usuario" value = {this.state.senha} onChange={this.AtualizaSenha} type="text" className="inputsLogin"></input>

                    <input placeholder="Digite o nome do usuario" value = {this.state.nome} onChange={this.AtualizaNome} type="text" className="inputsLogin"></input>
                    
                    {
                        <button type='submit' disabled={this.state.idTipoUsuario === '', this.state.email === '', this.state.senha === '', this.state.nome === '' ? 'none' : ''} className='buttonGeral1'>Cadastrar</button>
                    }
                        <button onClick={this.limparCampos} className='buttonGeral1'>
                            Cancelar
                        </button>
                </div>
            </form> 
                </section>
                
            </main>
        )}
}
export default ModalUsuario;