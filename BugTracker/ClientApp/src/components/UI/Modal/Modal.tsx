import React, {Dispatch, FC, SetStateAction} from 'react'
import cl from '../Modal/Modal.module.css'
interface ModalProps {
    active : boolean;
    setActive : () => void;
    children : React.ReactNode;
}

const Modal : FC<ModalProps> = ({active, setActive, children}) => {
  const classes = [cl.modal]
  if(active) {
    classes.push(cl.active)
  }

  return (
    <div className={classes.join(' ')} onClick={() => setActive()}>
        <div className={cl.modal__content} onClick={(e) => e.stopPropagation()}>
            {children}
        </div>
    </div>
  )
}

export default Modal