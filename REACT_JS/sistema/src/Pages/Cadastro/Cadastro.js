import { Component} from 'react';


class CadastraUsuario  extends Component{
    constructor(props){
        super(props);
        this.state = {
            email : '',
            senha : '',
            nome : ''
        }
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
    AtualizaNome = async(event) => {
        await this.setState({nome : event.target.value})
    }

    //---------------------------------------------------------------------------------------------------

    //CADASTRA UM NOVA USUARIO

    cadastranovousuario = (event) => {
        //IGNOROU O COMPORTAMENTO PADRÃO DO NAVEGADOR
        event.preventDefault();

        fetch('http://localhost:5000/api/Usuarios', {
                
            //DEFINE O METODO DA REQUISIÇÃO COMO POST
            method : 'POST',
                
            //CONVERTE A RESPOSTA RECEBIDA EM JSON
            body : JSON.stringify ({email : this.state.email, senha : this.state.senha, nome : this.state.nome  }),
            
            //DEFINE O CABEÇALHO DA REQUISIÇÃO
            headers : {
            "Content-Type" : "application/json"
            }
        });
    }

//---------------------------------------------------------------------------------------------------
    limparCampos = () => {
        this.setState({
            idTipoUsuario : 0,
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
                <h2>CADASTRO </h2>
                    <form onSubmit={this.cadastranovousuario}>
                <div className="Cadastrar">
                    
                    <input placeholder="Digite o email do usuario" value = {this.state.email} onChange={this.AtualizaEmail}type="text" className="gui2"></input>

                    
                    <input placeholder="Digite a senha do usuario" value = {this.state.senha} onChange={this.AtualizaSenha} type="text" className='gui2'></input>

                    
                    <input placeholder="Digite o Nome" value = {this.state.nome} onChange={this.AtualizaNome} type="text" className='gui2'></input>
                    
                    {
                        <button type='submit' disabled={this.state.email === '', this.state.senha === '', this.state.nome === '' ? 'none' : ''} >Cadastrar</button>
                    }
                        <button onClick={this.limparCampos}>
                            Cancelar
                        </button>
                </div>
            </form> 
                </section>
                
            </main>
        )}
}
export default CadastraUsuario;