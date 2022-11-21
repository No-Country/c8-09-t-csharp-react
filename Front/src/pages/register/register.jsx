import { Link } from "react-router-dom";
import { useState, useEffect } from "react";
import { useDispatch, useSelector } from "react-redux";
import { createUser } from "../../redux/actions";

import '../register/register.css'

function validateEmail(email) {
    return email.match(
        /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/
    );
};


function formValidations(input) {
    let formErrors = {}

    if (!input.email) {
        formErrors.email = "Email es necesario"
    }
    if (!input.username) {
        formErrors.username = "Nombre de Usuario se require"
    }
    if (!input.password) {
        formErrors.password = "Incluya mayuscula, minuscula, numero, simbolo"
    }
    if (!input.confirmPassword) {
        formErrors.confirmPassword = "Contraseñas deben de ser iguales"
    }
    if (input.password !== input.confirmPassword) {
        formErrors.passwordValidation = "Contraseñas deben de ser iguales"
    }
    if (!validateEmail(input.email)) {
        formErrors.emailInvalid = "Email invalido"
    }
    if (input.username.includes(" ")) {
        formErrors.usernameInvalid = "Nombre de usuario invalido"
    }

    return formErrors;
}

const Register = function () {

    const dispatch = useDispatch();
    const [formErrors, setFormErrors] = useState({})
    const [buttonState, setButtonState] = useState(true)
    const [input, setInput] = useState({
        email: "",
        username: "",
        password: "",
        confirmPassword: "",
        checked: false
    })

    function handleInput(e) {
        setInput({
            ...input,
            [e.target.name]: e.target.value,
        })
        setFormErrors(formValidations({
            ...input,
            [e.target.name]: e.target.value
        }))
    }

    function handleCheck(e) {
        if (e.target.checked) {
            setInput({
                ...input,
                checked: true
            })
        } else {
            setInput({
                ...input,
                checked: false
            })
        }
    }

    useEffect(() => {
        if (!input.checked || (Object.values(formErrors).length > 0 ||
            input.email === "" ||
            input.username === "" ||
            input.password === "" ||
            input.confirmPassword === "")) {
            setButtonState(true)
        } else {
            setButtonState(false)
        }
    }, [input])

    function submit(e) {
        e.preventDefault()
        let create = dispatch(createUser(input))
        create.then(val => {
            if(val !== 200){
                console.log(val)
                alert("Error: " + val)
            } else{
                console.log("Success with status: " + val)
                alert("Usuario creado con exito")
            }
        })
    }


    return (
        <div className="register_main">

            <div className="register_form_main">
                <div className="register_title">Crear cuenta</div>

                <button className="google_button">
                    <img className="google_icon" src="../../../G_Logo_Clean.png" alt="Google Icon" height={"24px"} width={"24px"} />
                    Continuar con Google
                </button>

                O

                <form className="register_form" onSubmit={submit}>

                    <input
                        className="form_button"
                        type="email"
                        name="email"
                        value={input.email}
                        placeholder="Email"
                        onChange={handleInput}
                    />
                    {formErrors.email && (<p className="warning">{formErrors.email}</p>) || formErrors.emailInvalid && (<p className="warning">{formErrors.emailInvalid}</p>)}

                    <input
                        className="form_button"
                        type="text"
                        name="username"
                        value={input.username}
                        placeholder="Usuario"
                        onChange={handleInput}
                    />
                    {formErrors.username && (<p className="warning">{formErrors.username}</p>) || formErrors.usernameInvalid && (<p className="warning">{formErrors.usernameInvalid}</p>)}

                    <input
                        className="form_button"
                        type="text"
                        name="password"
                        value={input.password}
                        placeholder="Contraseña"
                        onChange={handleInput}
                    />
                    {formErrors.password && (<p className="warning">{formErrors.password}</p>)}

                    <input
                        className="form_button"
                        type="text"
                        name="confirmPassword"
                        value={input.confirmPassword}
                        placeholder="Confirmar contraseña"
                        onChange={handleInput}
                    />
                    {formErrors.confirmPassword && (<p className="warning">{formErrors.confirmPassword}</p>) || formErrors.passwordValidation && (<p className="warning">{formErrors.passwordValidation}</p>)}

                    <div className="privacy_policy_main">

                        <input
                            className="privacy_policy_box"
                            type="checkbox"
                            name="privacyPolicy"
                            value={input.checked}
                            onChange={handleCheck}
                        />

                        <div>He leído y acepto la&nbsp;</div>
                        <div><Link className="privacy_policy_link" to="#"> Política de Privacidad</Link></div>
                    </div>

                    <button className="create_button" disabled={buttonState}>Crear cuenta</button>
                </form>

                <div>¿Ya tienes cuenta? <Link className="register_link" to="/login">Iniciar sesión</Link></div>
            </div>

        </div>
    )
}

export default Register;