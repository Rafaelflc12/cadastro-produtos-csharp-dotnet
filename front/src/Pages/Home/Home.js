import React from "react";
import '../../../src/App.css';
import { Link} from 'react-router-dom';


function Home() {
    return (
        <div className="App">
            <h3>
                Home
            </h3>
            <header className="App-header">
                <nav>
                    <ul>
                        <li >
                            <Link to="/Produto">Produto</Link>
                        </li>
                        <li >
                            <Link to="/Email">Email</Link>
                        </li>
                        <li >
                            <Link to="/Fornecedor">Fornecedor</Link>
                        </li>
                    </ul>
                </nav>
            </header>

        </div>
    );
}
export default Home;

