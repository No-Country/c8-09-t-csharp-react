import { useState } from "react";
import { useDispatch, useSelector } from 'react-redux'
import { Link } from "react-router-dom";

import "../login/login.css"
import { loginUser } from "../../redux/actions";


///////// ESTO ES PARA EL LOGIN DE GOOGLE /////////////
// import GoogleLogin from 'react-google-login';
// import { gapi } from "gapi-script";
// const idClientGoogleLogin = ""
//////////////////////////////////////////////////////


const Login = function () {

    const dispatch = useDispatch()
    // const loginData = useSelector(state => state.userloginData)

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
                    alert(`Error ${val.response.status}: ${val.response.statusText}`)
                } else {
                    alert("Bienvenido!")
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