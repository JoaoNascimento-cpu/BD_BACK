import react, {useState} from "react";
import Modal from "react-modal";

function ModalLogin() {
  const [modalIsOpen, setModalIsOpen] = useState(false)
  return (
    <div>
      <button onClick={() => setModalIsOpen(true)}>Open</button>
      <Modal isOpen={modalIsOpen} onRequestClose={() => setModalIsOpen(false)}>
        <h2>Deu Certo</h2>
        <p> Vai dar certo</p>
        <div>
        <button onClick={() => setModalIsOpen(false)}>Close</button>
        </div>
      </Modal>
    </div>
  );
}

export default ModalLogin;
