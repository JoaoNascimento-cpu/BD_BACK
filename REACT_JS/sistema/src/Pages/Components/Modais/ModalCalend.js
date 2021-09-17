import react, {useState,} from "react";
import Modal from "react-modal";
import Produto from '../Modalimport/ModalProduto'
import { Component } from "react";

function ModalLogin() {
  const [modalIsOpen, setModalIsOpen] = useState(false)
  return (
    <div>
      <button onClick={() => setModalIsOpen(true)}>Open</button>
      <Modal isOpen={modalIsOpen} onRequestClose={() => setModalIsOpen(false)}>
        <Produto/>
        <div>
        <button onClick={() => setModalIsOpen(false)}>Close</button>
        </div>
      </Modal>
    </div>
  );
}

export default ModalLogin;