import React from 'react';
import ReactDOM from 'react-dom';
import {Route, BrowserRouter as Router, Switch} from 'react-router-dom';


import App from './Pages/Home/App';
//import Login from './Pages/Login/Login.js';
import ModalProdutos2 from './Pages/Components/Modais/ModalProdutos2';
import ModalCadastro from './Pages/Components/Modalimport/ModalCadastro';
import ModalUsuario from './Pages/Components/Modalimport/ModalUsuario';
import AdmPage from './Pages/Adm/adm';

//import cars from './Pages/Card/Credit';

const routing = (
  <Router>
    <div>
        <Switch>
          <Route exact path="/" component={ModalProdutos2}/> 
          <Route path="/home" component={App}/>
        </Switch>
    </div>
  </Router>
)
ReactDOM.render(routing,document.getElementById('root'));


