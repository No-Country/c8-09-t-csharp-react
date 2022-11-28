import "./Nav.css"
import {Link} from "react-router-dom"
import { useEffect, useState } from "react"
import { clearLocalStorage } from "../../utils/localStorage"
import { useDispatch, useSelector } from 'react-redux'

const Nav = ({isAllowed}) => {  

    const loginData = useSelector(state => state.userloginData)

    useEffect(()=>{
        console.log(loginData)
    }, [])

    return(
        <nav>
            <div className="logo-links">
                <Link to={"/"} className="logo">
                    <img src="/logo-ticketfan.svg" alt="logo"/>
                </Link>
                <ul>
                    <li className="active"><Link to={"/"} >Inicio</Link></li>
                    <li><Link to={"/"}>Categorias</Link></li>
                    <li><Link to={"/"}>Contacto</Link></li>
                </ul>
            </div>
            <div className="button-carrito">
                {isAllowed ?
                <div className="buttonIngresar" onClick={()=>{
                    //clearLocalStorage("user")
                }}>
                    <img src="/perfil.svg" alt="perfil" />
                    <span>Cerrar sesion</span>
                </div> :
                <Link to={"/login"}>
                    <div className="buttonIngresar">
                        <img src="/perfil.svg" alt="perfil" />
                        <span>Ingresar</span>
                    </div>
                </Link>
                }
                <Link to={"/"}><img src="/carrito.svg" alt="carrito"/></Link> 
            </div>
        </nav>
    )
}

export default Nav;
