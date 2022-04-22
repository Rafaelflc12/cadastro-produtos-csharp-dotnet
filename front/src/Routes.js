import React from "react";
import { Switch , Route} from 'react-router-dom';
import Produto from "./Pages/Produto/Produto";
import Home from './Pages/Home/Home';
import Fornecedor from "./Pages/Fornecedor/Fornecedor";
import Email from './Pages/Email/Email';
import '../src/App.css';
export default () => {
    return (
        <Switch>
            <Route exact path="/">
            <Home/>

            </Route>

            <Route exact path="/Produto">
            <Produto/>

            </Route>
            <Route exact path="/Fornecedor">
            <Fornecedor/>

            </Route>
            <Route exact path="/Email">
            <Email/>

            </Route>
        </Switch>
    );
}