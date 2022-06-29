import React from 'react'
import cl from '../Input/Input.module.css'
const Input = (props:any) => {
  return (
    <input className={cl.input} {...props}></input>
  )
}

export default Input