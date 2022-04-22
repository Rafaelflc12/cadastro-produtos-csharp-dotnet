import '../../App.css';
import 'bootstrap/dist/css/bootstrap.min.css';
import axios from 'axios';
import { Modal, ModalBody, ModalFooter, ModalHeader } from 'reactstrap';
import React, { useState, useEffect } from 'react';
import {Link} from 'react-router-dom';



function Produto() {

  const baseUrl = "https://localhost:7233/api/Produto";


  const [data, setData] = useState([]);
  const [updateData, setUpdateData] = useState(true);
  const [modalIncluir, setModalIncluir] = useState(false);
  const [modalEditar, setModalEditar] = useState(false);
  const [modalExcluir, setModalExcluir] = useState(false);

  const [produtoSelecionado, setProdutoSelecionado] = useState({
    id: '',
    nome: '',
    descricao: ''
  })

  const selecionarProduto = (produto, opcao) => {
    setProdutoSelecionado(produto);
    (opcao === "Editar") ?
      abrirFecharModalEditar(): abrirFecharModalExluir();
  }

  const abrirFecharModalIncluir = () => {
    setModalIncluir(!modalIncluir);
  }
  const abrirFecharModalEditar = () => {
    setModalEditar(!modalEditar);
  }

  const abrirFecharModalExluir = () => {
    setModalExcluir(!modalExcluir);
  }

  const handleChange = e => {
    const { name, value } = e.target;
    setProdutoSelecionado({
      ...produtoSelecionado, [name]:value
    });
    console.log(produtoSelecionado);
  }





  const pedidoGet = async () => {
    await axios.get(baseUrl).then(response => {
      setData(response.data);
    }).catch(error => {
      console.log(error);
    })
  }




  const pedidoPost = async () => {
    

    await axios.post(baseUrl, produtoSelecionado).then(response => {
      setData(data.concat(response.data));
      setUpdateData(true);
      abrirFecharModalIncluir();
    }).catch(error => {
      console.log(error);
    })
  }




  const pedidoPut = async () => {
    await axios.put(baseUrl+"/"+produtoSelecionado.id, produtoSelecionado).then(response => {
        var resposta = response.data;
        var dadosAuxiliar = data;
        dadosAuxiliar.map(produto => {
          if (produto.id === produtoSelecionado.id) {
            produto.nome = resposta.nome;
            produto.descricao = resposta.descricao;
          } 
          return produto;
        });
        setUpdateData(true);
        abrirFecharModalEditar();
      }).catch(error => {
        console.log(error);
      })
  }



const pedidoDelete=async()=>{
  await axios.delete(baseUrl+"/"+produtoSelecionado.id)
  .then(response=>{
    setData(data.filter(produto=> produto.id !== response.data));
    setUpdateData(true);
    abrirFecharModalExluir();
  }).catch(error=>{
    console.log(error);
  })
}




  useEffect(() => {
    if(updateData) {
      pedidoGet();
      setUpdateData(false);
    }
  }, [ updateData])

  return (
    <div className="App">
      <header className="App-header">
      <nav>
        <ul>
            <li >
                 <Link to="/">Home</Link>
            </li>
            <li >
                 <Link to="/Email">Email</Link>
            </li>
            <li >
                 <Link to="/Fornecedor">Fornecedor</Link>
            </li>
        </ul>
      </nav>
      
      <h3>Cadastro de Produtos e Fornecedores</h3>

      
        <button className='btn btn-success' onClick={() => abrirFecharModalIncluir()}>Incluir Produto</button>
      </header>
      <br></br>
      <table className='table table-bordered'>
        <thead>
          <tr>
            <th>Id</th>
            <th>Nome</th>
            <th>Descrição</th>

          </tr>
        </thead>
        <tbody>
          {
            data.map(produto => (
              <tr key={produto.id}>
                <td>{produto.id}</td>
                <td>{produto.nome}</td>
                <td>{produto.descricao}</td>

                <td>
                  <button className='btn btn-primary' onClick={() => selecionarProduto(produto, "Editar")}> Editar</button>{"  "}
                  <button className='btn btn-danger' onClick={() => selecionarProduto(produto, "Excluir")}>Excluir </button>
                </td>
              </tr>
            ))
          }
        </tbody>
      </table>
      <Modal isOpen={modalIncluir}>
        <ModalHeader>Incluir Produtos</ModalHeader>
        <ModalBody>
          <div className='form-group'>
            <label>Nome:</label>
            <br></br>
            <input type="text" className="form-control" name='nome' onChange={handleChange}
              value={produtoSelecionado && produtoSelecionado.nome} />
            <br></br>
            <label>Descrição:</label>
            <br></br>
            <input type="text" className="form-control" name='descricao' onChange={handleChange}
              value={produtoSelecionado && produtoSelecionado.descricao} />
            <br></br>

          </div>
        </ModalBody>
        <ModalFooter>
          <button className='btn btn-primary' onClick={() => pedidoPost()}>Incluir</button> {" "}
          <button className='btn btn-danger' onClick={() => abrirFecharModalIncluir()}>Cancelar</button>
        </ModalFooter>
      </Modal>

      <Modal isOpen={modalEditar}>
        <ModalHeader>Editar Produtos</ModalHeader>
        <ModalBody>
          <div className='form-group'>
            <label >ID: </label><input type="text"readOnly value={produtoSelecionado && produtoSelecionado.id}/>
            <br/>
            <label>Nome:</label>
            <br></br>
            <input type="text" className="form-control" name='nome' onChange={handleChange} value={produtoSelecionado && produtoSelecionado.nome} />
            <br></br>
            <label>Descrição:</label>
            <br></br>
            <input type="text" className="form-control" name='descricao' onChange={handleChange} value={produtoSelecionado && produtoSelecionado.descricao} />
            <br></br>

          </div>
        </ModalBody>
        <ModalFooter>
          <button className='btn btn-primary' onClick={() => pedidoPut()}>Editar</button> {" "}
          <button className='btn btn-danger' onClick={() => abrirFecharModalEditar()}>Cancelar</button>
        </ModalFooter>
      </Modal>


        <Modal isOpen={modalExcluir}>
          <ModalBody>
            Confirma a exclusão deste produto: {produtoSelecionado && produtoSelecionado.nome}?
          </ModalBody>
          <ModalFooter>
            <button className='btn btn-danger' onClick={() => pedidoDelete()}>Sim</button>
            <button className='btn btn-secondary' onClick={() => abrirFecharModalExluir()}>Não</button>
          </ModalFooter>
        </Modal>
    </div>
  );
}


export default Produto;
