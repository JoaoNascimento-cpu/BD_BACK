import React from 'react';
import ReactDOM from 'react-dom';
import {Route, BrowserRouter as Router, Switch} from 'react-router-dom';


import App from './Pages/Home/App';
import Login from './Pages/Login/Login.js';
import ModalCadastro from './Pages/Components/Modalimport/ModalCadastro';

//import cars from './Pages/Card/Credit';

const routing = (
  <Router>
    <div>
        <Switch>
          <Route exact path="/" component={Login}/> 
          <Route path="/home" component={App}/>
        </Switch>
    </div>
  </Router>
)
ReactDOM.render(routing,document.getElementById('root'));


