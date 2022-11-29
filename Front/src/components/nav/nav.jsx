import "./Nav.css"
import {Link} from "react-router-dom"
import { useDispatch, useSelector } from "react-redux"
import { useEffect} from "react"
import { checkLocalStorage } from "../../redux/actions"
import { clearLocalStorage } from "../../utils/localStorage"

const Nav = () => {      

    const dispatch = useDispatch()
    const isLogged = useSelector(state => state.isLogged)

    useEffect(()=> {
        dispatch(checkLocalStorage())
        console.log(isLogged)
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
                {isLogged ? 
                <div className="buttonIngresar" onClick={() =>{
                    clearLocalStorage("user")
                    dispatch(checkLocalStorage())
                }}>
                    <img src="/perfil.svg" alt="perfil" />
                    <span>Cerrar sesion</span>
                </div>
                :
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
