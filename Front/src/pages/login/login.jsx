import { Alert } from "../../utils/alert";
import rejectionImg from '../../../src/rejection.svg'
import responseImg from '../../../src/response.svg'
import { useState } from "react";
import { useDispatch, useSelector } from 'react-redux'
import { Link, useNavigate } from "react-router-dom";
import jwt_decode from "jwt-decode";
import { checkLocalStorage } from "../../redux/actions";

import "../login/login.css"
import { loginUser } from "../../redux/actions";
import { useEffect } from "react";


const Login = function () {

    const navigate = useNavigate()
    const loginData = useSelector(state => state.userloginData)
    const dispatch = useDispatch()
    const [input, setInput] = useState({
        email: "",
        password: ""
    })

    function handleInput(e) {
        setInput({
            ...input,
            [e.target.name]: e.target.value
        })
    }

    
    function submit(e) {
        e.preventDefault()
        dispatch(loginUser(input))
            .then(val => {
                if (val !== 200) {
                    // alert(`Error ${val.response.status}: ${val.response.statusText}`)
                    // alert("Error")
                    Alert.fire({
                        title: 'Ooops',
                        html: `Por favor verifica los datos: </br> <b>${input.email}</b>`,
                        imageUrl: rejectionImg,
                        imageAlt: 'error',
                        confirmButtonText: `<button class="botonPrincipal" >OK</button>`,
                    })
                    
                } else {
                    try{
                        // const decode = jwt_decode(loginData.token)
                        // localStorage.setItem("user", JSON.stringify(decode))
                        Alert.fire({
                            title: 'Bienvenido!',
                            html: `Ingresaste con el correo: </br> <b>${input.email}</b>`,
                            imageUrl: responseImg,
                            imageAlt: 'confirm',
                            confirmButtonText: `<button class="botonPrincipal" >OK</button>`,
                        })
                        dispatch(checkLocalStorage())
                        navigate("/")
                     
                    } catch(error){
                        Alert.fire({
                            title: 'Lo siento',
                            html: `Ha ocurrido un error </br> Por favor inténtelo de nuevo más tarde`,
                            icon:"error",
                            confirmButtonText: `<button class="botonPrincipal" >OK</button>`,
                        })
                    }
                }
            })
    }
    

    
    return (
        <div className="login_main">

            <div className="login_form_main">
                <div className="login_form_subcontainer">
                <div className="login_title">Ingresar a tu Cuenta</div>
                <button className="google_button">
                    <img className="google_icon" src="../../../G_Logo_Clean.png" alt="Google Icon" height={"24px"} width={"24px"} />
                    Continuar con Google
                </button>

                <br />
                O

                <form className="login_form" autoComplete="off" onSubmit={submit}>
                    <input
                        className="form_button"
                        type="text"
                        name="email"
                        placeholder="Email"
                        value={input.email}
                        onChange={handleInput} />

                    <input
                        className="form_button"
                        type="password"
                        name="password"
                        placeholder="Contraseña"
                        
                        value={input.password}
                        onChange={handleInput}
                    />

                    <div className="forgot_password"><Link to="/forgotPassword">¿Olvidaste tu contraseña?</Link></div>

                    <button className="login_button">Iniciar Sesión</button>
                </form>

                <div>¿No tienes una cuenta? <Link className="register_link" to="/register">Regístrate</Link></div>
            </div>
                </div>
        </div>
    )
}

export default Login;