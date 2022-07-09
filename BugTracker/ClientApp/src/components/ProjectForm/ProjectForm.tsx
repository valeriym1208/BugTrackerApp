import React, {useState} from 'react'
import Input from '../UI/Input/Input'
import Textarea from '../UI/Textarea/Textarea'
import Select from '../UI/Select/Select'
import cl from '../ProjectForm/ProjectForm.module.css'
const ProjectForm = () => {
  const [projectName, setProjectName] = useState<string>('')
  const [projectDescription, setProjectDescription] = useState<string>('')

  const changeNameHandler = (e:React.ChangeEvent<HTMLInputElement>) => {
    setProjectName(e.target.value)
  }

  const changeDescriptionHandler = (e:React.ChangeEvent<HTMLTextAreaElement>) => {
    setProjectDescription(e.target.value)
  }
  return (
    <form>
        <h5>Add new project</h5>
        <label htmlFor="Input" className={cl.label}>Project name:</label>
        <Input
          type='text'
          value={projectName}
          placeholder='Give a title to your project'
          onChange={changeNameHandler}
        >
        </Input>
        <label htmlFor="Textarea" className={cl.label}>Project description:</label>
        <Textarea 
          type='text'
          value={projectDescription}
          placeholder='Give a title to your project'
          onChange={changeDescriptionHandler}
        >
        </Textarea>
        <label htmlFor="Select" className={cl.label}>Add team members:</label>
        <Select multiple={true} required size={5}></Select>
        <button className='form__button'>Add project</button>
    </form>
  )
}

export default ProjectForm