import { useState } from "react";
import { useDispatch, useSelector } from 'react-redux'
import { Link, useNavigate } from "react-router-dom";
import jwt_decode from "jwt-decode";


import "../login/login.css"
import { loginUser } from "../../redux/actions";
import { useEffect } from "react";



const Login = function () {

    const navigate = useNavigate()
    const loginData = useSelector(state => state.userloginData)
    const dispatch = useDispatch()
<<<<<<< HEAD
    const loginResponse = useSelector(state => state.userloginData)
=======
>>>>>>> f603c61992ea1e1fca2e92f29d9b451475be54e8

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
                    alert("Error")
                } else {
<<<<<<< HEAD
                    const decoded = jwt.decode(loginResponse.token)
                    console.log(decoded)
                    // localStorage.setItem("loginData", JSON.stringify({...loginResponse}))
                    alert("Bienvenido!")
=======
                    try{
                        // const decode = jwt_decode(loginData.token)
                        // localStorage.setItem("user", JSON.stringify(decode))
                        alert("Bienvenido!")
                        navigate("/")
                     
                    } catch(error){
                        console.log(error)
                    }
>>>>>>> f603c61992ea1e1fca2e92f29d9b451475be54e8
                }
            })
    }
    

    
    return (
        <div className="login_main">

            <div className="login_form_main">
                <div className="login_title">Ingresar a tu Cuenta</div>
                <button className="google_button">
                    <img className="google_icon" src="../../../G_Logo_Clean.png" alt="Google Icon" height={"24px"} width={"24px"} />
                    Continuar con Google
                </button>

                <br />
                O

                <form className="login_form" onSubmit={submit}>
                    <input
                        className="form_button"
                        type="text"
                        name="email"
                        placeholder="Email"
                        value={input.email}
                        onChange={handleInput} />

                    <input
                        className="form_button"
                        type="text"
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
    )
}

export default Login;