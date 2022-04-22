import '../../App.css';
import 'bootstrap/dist/css/bootstrap.min.css';
import axios from 'axios';
import { Modal, ModalBody, ModalFooter, ModalHeader } from 'reactstrap';
import React, { useState, useEffect } from 'react';
import {Link} from 'react-router-dom';



function Fornecedor() {

  const baseUrl = "https://localhost:7233/api/Fornecedor";


  const [data, setData] = useState([]);
  const [updateData, setUpdateData] = useState(true);
  const [modalIncluir, setModalIncluir] = useState(false);
  const [modalEditar, setModalEditar] = useState(false);
  const [modalExcluir, setModalExcluir] = useState(false);

  const [selecionado, setSelecionado] = useState({
    id: '',
    nome: '',
    descricao: '',
    cidade:'',
    endereco:'',
    bairro:'',
    numero:'',
    telefone:'',
    email:''
  })

  const selecionar = (fornecedor, opcao) => {
    setSelecionado(fornecedor);
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
    setSelecionado({
      ...selecionado, [name]:value
    });
    console.log(selecionado);
  }





  const pedidoGet = async () => {
    await axios.get(baseUrl).then(response => {
      setData(response.data);
    }).catch(error => {
      console.log(error);
    })
  }




  const pedidoPost = async () => {
    

    await axios.post(baseUrl, selecionado).then(response => {
      setData(data.concat(response.data));
      setUpdateData(true);
      abrirFecharModalIncluir();
    }).catch(error => {
      console.log(error);
    })
  }




  const pedidoPut = async () => {
    await axios.put(baseUrl+"/"+selecionado.id, selecionado).then(response => {
        var resposta = response.data;
        var dadosAuxiliar = data;
        dadosAuxiliar.map(fornecedor => {
          if (fornecedor.id === selecionado.id) {
            fornecedor.nome = resposta.nome;
            fornecedor.descricao = resposta.descricao;
            fornecedor.cidade = resposta.cidade;
            fornecedor.endereco = resposta.endereco;
            fornecedor.bairro = resposta.bairro;
            fornecedor.numero = resposta.numero;
          } 
          return fornecedor;
        });
        setUpdateData(true);
        abrirFecharModalEditar();
      }).catch(error => {
        console.log(error);
      })
  }



const pedidoDelete=async()=>{
  await axios.delete(baseUrl+"/"+selecionado.id)
  .then(response=>{
    setData(data.filter(fornecedor=> fornecedor.id !== response.data));
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
                 <Link to="/Produto">Produto</Link>
            </li>
        </ul>
      </nav>
      
      <h3>Cadastro de Produtos </h3>

      
        <button className='btn btn-success' onClick={() => abrirFecharModalIncluir()}>Incluir Fornecedor</button>
      </header>
      <br></br>
      <table className='table table-bordered'>
        <thead>
          <tr>
            <th>Id</th>
            <th>Nome</th>
            <th>Descrição</th>
            <th>Cidade</th>
            <th>Endereço</th>
            <th>Bairro</th>
            <th>Número</th>
            <th>telefone</th>
            <th>Email</th>

          </tr>
        </thead>
        <tbody>
          {
            data.map(fornecedor => (
              <tr key={fornecedor.id}>
                <td>{fornecedor.id}</td>
                <td>{fornecedor.nome}</td>
                <td>{fornecedor.descricao}</td>
                <td>{fornecedor.cidade}</td>
                <td>{fornecedor.endereco}</td>
                <td>{fornecedor.bairro}</td>
                <td>{fornecedor.numero}</td>
                <td>{fornecedor.telefone}</td>
                <td>{fornecedor.email}</td>

                <td>
                  <button className='btn btn-primary' onClick={() => selecionar(fornecedor, "Editar")}> Editar</button>{"  "}
                  <button className='btn btn-danger' onClick={() => selecionar(fornecedor, "Excluir")}>Excluir </button>
                </td>
              </tr>
            ))
          }
        </tbody>
      </table>
      <Modal isOpen={modalIncluir}>
        <ModalHeader>Incluir Fornecedores</ModalHeader>
        <ModalBody>
          <div className='form-group'>
            <label>Nome:</label>
            <br></br>
            <input type="text" className="form-control" name='nome' onChange={handleChange}
              value={selecionado && selecionado.nome} />
            <br></br>
            <label>Descrição:</label>
            <br></br>
            <input type="text" className="form-control" name='descricao' onChange={handleChange}
              value={selecionado && selecionado.descricao} />
            <br></br>
            <input type="text" className="form-control" name='cidade' onChange={handleChange}
              value={selecionado && selecionado.cidade} />
            <br></br>
            <input type="text" className="form-control" name='endereco' onChange={handleChange}
              value={selecionado && selecionado.endereco} />
            <br></br>
            <input type="text" className="form-control" name='bairro' onChange={handleChange}
              value={selecionado && selecionado.bairro} />
            <br></br>
            <input type="text" className="form-control" name='numero' onChange={handleChange}
              value={selecionado && selecionado.numero} />
            <br></br>

          </div>
        </ModalBody>
        <ModalFooter>
          <button className='btn btn-primary' onClick={() => pedidoPost()}>Incluir</button> {" "}
          <button className='btn btn-danger' onClick={() => abrirFecharModalIncluir()}>Cancelar</button>
        </ModalFooter>
      </Modal>

      <Modal isOpen={modalEditar}>
        <ModalHeader>Editar Fornecedor</ModalHeader>
        <ModalBody>
          <div className='form-group'>
            <label >ID: </label><input type="text"readOnly value={selecionado && selecionado.id}/>
            <br/>
            <label>Nome:</label>
            <br></br>
            <input type="text" className="form-control" name='nome' onChange={handleChange} value={selecionado && selecionado.nome} />
            <br></br>
            <label>Descrição:</label>
            <br></br>
            <input type="text" className="form-control" name='descricao' onChange={handleChange} value={selecionado && selecionado.descricao} />
            <br></br>
            <input type="text" className="form-control" name='cidade' onChange={handleChange}
              value={selecionado && selecionado.cidade} />
            <br></br>
            <input type="text" className="form-control" name='endereco' onChange={handleChange}
              value={selecionado && selecionado.endereco} />
            <br></br>
            <input type="text" className="form-control" name='bairro' onChange={handleChange}
              value={selecionado && selecionado.bairro} />
            <br></br>
            <input type="text" className="form-control" name='numero' onChange={handleChange}
              value={selecionado && selecionado.numero} />
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
            Confirma a exclusão deste fornecedor: {selecionado && selecionado.nome}?
          </ModalBody>
          <ModalFooter>
            <button className='btn btn-danger' onClick={() => pedidoDelete()}>Sim</button>
            <button className='btn btn-secondary' onClick={() => abrirFecharModalExluir()}>Não</button>
          </ModalFooter>
        </Modal>
    </div>
  );
}


export default Fornecedor;
