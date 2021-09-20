import react, {useState,} from "react";
import Modal from "react-modal";
import { Component } from "react";
import ModalProdutos from '../Modalimport/ModalProduto'

function ModalProdutos2() {
  const [modalIsOpen, setModalIsOpen] = useState(false)
  return (
    <div>
      <button onClick={() => setModalIsOpen(true)}>Open</button>
      <Modal isOpen={modalIsOpen} onRequestClose={() => setModalIsOpen(false)}>
        <ModalProdutos/>
        <div>
        <button onClick={() => setModalIsOpen(false)}>Close</button>
        </div>
      </Modal>
    </div>
  );
}

export default ModalProdutos2;