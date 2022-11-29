import "./Nav.css"
import {Link} from "react-router-dom"
import { useEffect} from "react"

const Nav = () => {  

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
                <Link to={"/login"}>
                    <div className="buttonIngresar">
                        <img src="/perfil.svg" alt="perfil" />
                        <span>Ingresar</span>
                    </div>
                </Link>
                <Link to={"/"}><img src="/carrito.svg" alt="carrito"/></Link> 
            </div>
        </nav>
    )
}

export default Nav;
