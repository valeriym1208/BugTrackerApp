import React from 'react'
import ProjectsSection from '../ProjectsSection/ProjectsSection'
import cl from '../Dashboard/Dashboard.module.css'
interface DashboardProps {
  
}

const Dashboard = () => {
  return (
    <div className={cl.dashboard}>
      <h2 className={cl.dashboard__title}>Dashboard</h2>
      <ProjectsSection></ProjectsSection>
    </div>
  ) 
}

export default Dashboard