import React from 'react'
import cl from '../Navbar/Navbar.module.css'
const Navbar = () => {
  return (
    <nav className={cl.navbar}>
        <a href='' className={cl.navbar__logo}>Bug tracker</a>
        <ul className={cl.navbar__list}>
            <li className={cl.navbar__item}><a href="">Dashboard</a></li>
            <li className={cl.navbar__item}><a href="">Tickets</a></li>
            <li className={cl.navbar__item}><a href="">Administration</a></li>
        </ul>
    </nav>
  )
}

export default Navbar