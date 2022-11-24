import '../forgotPassword/forgotPassword.css'
import { Link } from 'react-router-dom';

const ForgotPassword = function () {


    // Funcion que va a checar si el correo existe 

    // 
    return (
        <div className="forgotpassword_main">
            <div className="forgotpassword_form_main">

                <div className='forgotpassword_data'>
                    <div className="forgotpassword_title">Recuperar Contraseña</div>

                    <div className='reset_description'>
                        <p>
                            Si olvidaste la contraseña de acceso a tu cuenta, por favor,
                            introduce el email con el que te registraste y te enviaremos
                            las instrucciones para recuperar tu contraseña:
                        </p>
                    </div>

                    <form className="forgotpassword_form">
                        <input className="forgotpassword_email" type="text" placeholder="Email" />

                        <div className='forgot_buttons'>
                            <Link className='cancel_button' to="/login">Cancelar</Link>
                            {/* <button className='cancel_button'>Cancelar</button> */}
                            <button className="reset_button" onClick={(e) => e.preventDefault()}>Recuperar mi contraseña</button>
                        </div>
                    </form>

                </div>
            </div>
        </div>
    )
}

export default ForgotPassword;