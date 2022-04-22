import '../../App.css';
import 'bootstrap/dist/css/bootstrap.min.css';
import axios from 'axios';
import { Modal, ModalBody, ModalFooter, ModalHeader } from 'reactstrap';
import React, { useState, useEffect } from 'react';
import {Link} from 'react-router-dom';



function Email() {

  const baseUrl = "https://localhost:7233/api/Email";


  const [data, setData] = useState([]);
  const [updateData, setUpdateData] = useState(true);
  const [modalIncluir, setModalIncluir] = useState(false);
  const [modalEditar, setModalEditar] = useState(false);
  const [modalExcluir, setModalExcluir] = useState(false);

  const [selecionado, setSelecionado] = useState({
    id: '',
   email:'',
   referencia:''
  })

  const selecionar = (email, opcao) => {
    setSelecionado(email);
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
        dadosAuxiliar.map(email => {
          if (email.id === selecionado.id) {
            email.email = resposta.email;
            email.referencia = resposta.referencia;
           
          } 
          return email;
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
    setData(data.filter(email=> email.id !== response.data));
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
                 <Link to="/Fornecedor">Fornecedor</Link>
            </li>
            <li >
                 <Link to="/Produto">Produto</Link>
            </li>
        </ul>
      </nav>
      
      <h3>Cadastro de email </h3>

      
        <button className='btn btn-success' onClick={() => abrirFecharModalIncluir()}>Incluir Email</button>
      </header>
      <br></br>
      <table className='table table-bordered'>
        <thead>
          <tr>
            <th>Id</th>
            <th>Email</th>
            <th>Referencia</th>
            

          </tr>
        </thead>
        <tbody>
          {
            data.map(email => (
              <tr key={email.id}>
                <td>{email.id}</td>
                <td>{email.email}</td>
                <td>{email.referencia}</td>

                <td>
                  <button className='btn btn-primary' onClick={() => selecionar(email, "Editar")}> Editar</button>{"  "}
                  <button className='btn btn-danger' onClick={() => selecionar(email, "Excluir")}>Excluir </button>
                </td>
              </tr>
            ))
          }
        </tbody>
      </table>
      <Modal isOpen={modalIncluir}>
        <ModalHeader>Incluir Email</ModalHeader>
        <ModalBody>
          <div className='form-group'>
            <label>Email:</label>
            <br></br>
            <input type="text" className="form-control" name='email' onChange={handleChange}
              value={selecionado && selecionado.email} />
            <br></br>
            <label>Referencia:</label>
            <br></br>
            <input type="text" className="form-control" name='referencia' onChange={handleChange}
              value={selecionado && selecionado.referencia} />
            <br></br>
            
          </div>
        </ModalBody>
        <ModalFooter>
          <button className='btn btn-primary' onClick={() => pedidoPost()}>Incluir</button> {" "}
          <button className='btn btn-danger' onClick={() => abrirFecharModalIncluir()}>Cancelar</button>
        </ModalFooter>
      </Modal>

      <Modal isOpen={modalEditar}>
        <ModalHeader>Editar Email</ModalHeader>
        <ModalBody>
          <div className='form-group'>
            <label >ID: </label><input type="text"readOnly value={selecionado && selecionado.id}/>
            <br/>
            <label>Email:</label>
            <br></br>
            <input type="text" className="form-control" name='email' onChange={handleChange}
              value={selecionado && selecionado.email} />
            <br></br>
            <label>Referencia:</label>
            <br></br>
            <input type="text" className="form-control" name='referencia' onChange={handleChange}
              value={selecionado && selecionado.referencia} />
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
            Confirma a exclusão deste email: {selecionado && selecionado.email}?
          </ModalBody>
          <ModalFooter>
            <button className='btn btn-danger' onClick={() => pedidoDelete()}>Sim</button>
            <button className='btn btn-secondary' onClick={() => abrirFecharModalExluir()}>Não</button>
          </ModalFooter>
        </Modal>
    </div>
  );
}


export default Email;
