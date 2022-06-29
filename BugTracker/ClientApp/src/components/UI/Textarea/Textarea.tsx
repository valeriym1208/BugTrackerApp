import React from 'react'
import cl from '../Textarea/Textarea.module.css'
const Textarea = (props:any) => {
  return (
    <textarea className={cl.textarea} {...props}>
    </textarea>
  )
}

export default Textarea