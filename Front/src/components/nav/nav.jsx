import "./Nav.css"
import { useDispatch, useSelector } from "react-redux"
import { useEffect, useState} from "react"
import { checkLocalStorage } from "../../redux/actions"
import { Link, useNavigate } from "react-router-dom"
import { clearLocalStorage } from "../../utils/localStorage"

//Tailwind components
import { Menu } from '@headlessui/react'
import { ChevronDownIcon } from '@heroicons/react/20/solid'


const Nav = () => {     
    const navigate = useNavigate()
    const userInfo = useSelector(state => state.userloginData)
    const userStorage = useSelector(state => state.singleUser)
    const token = useSelector(state => state.token)
    const [userName, setUserName] = useState("Nadir Blanco")
    const dispatch = useDispatch()
    const isLogged = useSelector(state => state.isLogged)

    //const [encodedData, setEncodedData] = useState("")
    //const [decodedData, setDecodedData] = useState("")

    const items = [
        {
            name: "Mi cuenta",
            ruta: `https://ticketfanadmin.netlify.app/login/${token}`,
            action: function(){
                console.log(token)
                /* console.log(userStorage.jti)
                console.log(encodedData)
                console.log(decodedData) */
            }
        },
        {
            name: "Cerrar sesion",
            ruta: "/",
            action: function(){
                clearLocalStorage("user")
                clearLocalStorage("token")
                dispatch(checkLocalStorage())
            }
        },
    ]

    useEffect(()=> {
        dispatch(checkLocalStorage())
    }, [])

    /* useEffect(()=>{
        setEncodedData(btoa(userStorage.jti))
    }, [userStorage])

    useEffect(()=>{
        setDecodedData(atob(encodedData))
    }, [encodedData]) */

    useEffect(()=> {
        setUserName(userInfo["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"])
    }, [userInfo])

    return(
        <nav>
            <div className="logo-links">
                <Link to={"/"} className="logo">
                    <img src="/logo-ticketfan.svg" alt="logo"/>
                </Link>
                <ul>
                    <li className="active"><Link to={"/"} >Inicio</Link></li>
                    <li className="active"><Link to={"/catalogo"} >Catalogo</Link></li>
                </ul>
            </div>
            <div className="button-carrito">
                {isLogged ? 
                <Menu as="div" className="relative inline-block text-left">
                    <div>
                        <Menu.Button className="inline-flex w-full justify-center rounded-2xl bg-pink-500 px-4 py-2 text-sm font-medium text-white shadow-sm hover:bg-pink-600">
                        {userInfo.length === 0 ? userStorage["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"]:
                        userName
                        }
                        <ChevronDownIcon className="-mr-1 ml-2 h-5 w-5" aria-hidden="true" />
                        </Menu.Button>
                    </div>
                    <Menu.Items className="absolute right-0 z-10 mt-2 w-56 origin-top-right rounded-md bg-white shadow-lg ring-1 ring-black ring-opacity-5 focus:outline-none">
                        <div className="py-1">
                            {items.map((i, index)=>{
                                return(
                                <Menu.Item key={index} onClick={()=>{
                                    i.action()
                                }}>
                                    <a
                                    href={i.ruta}
                                    className={'bg-gray-100 text-gray-900 block px-4 py-2 text-md font-semibold'}
                                    >
                                    {i.name}
                                    </a>
                                </Menu.Item>
                                )
                            })}
                        </div>
                    </Menu.Items>
                </Menu>
                :
                <Link to={"/login"}>
                    <div className="buttonIngresar">
                        <img src="/perfil.svg" alt="perfil" />
                        <span>Ingresar</span>
                    </div>
                </Link>
                }
            </div>
        </nav>
    )
}

export default Nav;
