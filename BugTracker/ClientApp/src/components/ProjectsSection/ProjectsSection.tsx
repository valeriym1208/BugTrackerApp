import React, { useState } from 'react'
import cl from "../ProjectsSection/ProjectsSection.module.css"
import Modal from '../UI/Modal/Modal'
import ProjectForm from '../ProjectForm/ProjectForm'
const ProjectsSection = () => {
  const [modalActive, setModalActive] = useState<boolean>(false)
  const modalActiveHandler = () => {
    setModalActive(!modalActive)
  }
  return (
    <div className={cl.projects}>
        <div className={cl.projects__header}>
            <h3 className={cl.projects__title}>Projects</h3>
            <button className="button" onClick={modalActiveHandler}>New project</button>
            <Modal active={modalActive} setActive={modalActiveHandler}>
                <ProjectForm></ProjectForm>
            </Modal> 
        </div>
        <table className={cl.projects__table}>
            <thead>
                <tr>
                    <th>Project</th>
                    <th>Description</th>
                    <th>Contributors</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td>Bug tracker</td>
                    <td>My first pet project</td>
                    <td>Valeriy Mashkin</td>
                </tr>
            </tbody>
            <tbody>
                <tr>
                    <td>Bug tracker</td>
                    <td>My first pet project</td>
                    <td>Valeriy Mashkin</td>
                </tr>
            </tbody>
        </table>
    </div>
  )
}

export default ProjectsSection