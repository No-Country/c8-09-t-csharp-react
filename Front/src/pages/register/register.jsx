import { Link } from "react-router-dom";

import '../register/register.css'

const Register = function(){
    return(
        <div className="register_main">
            
            <div className="register_form_main">
                <div className="register_title">Crear cuenta</div>
                
                {/* <input className="google_button" type="image" src="../../../G_Icon.png" width={"24px"} height={"24px"} float={"right"} /> */}
        
                <button className="google_button">
                   <img className="google_icon" src="../../../G_Logo_Clean.png" alt="Google Icon" height={"24px"} width={"24px"}/>
                    Continuar con Google
                </button>
                
                <br />
                O 
                <form className="register_form">
                    <input className="form_button" type="email" placeholder="Email" />
                    <input className="form_button" type="text" placeholder="Contraseña" />
                    <input className="form_button" type="password" placeholder="Confirmar contraseña" />
                    
                    <div className="privacy_policy_main">
                        <input className="privacy_policy_box" type="checkbox" />
                        <div>He leído y acepto la&nbsp;</div>
                        <div><Link className="privacy_policy_link" to="#"> Política de Privacidad</Link></div>
                    </div>
                    
                    <button className="create_button">Crear cuenta</button>
                </form>

                <div>¿Ya tienes cuenta? <Link className="register_link" to="/login">Iniciar sesión</Link></div>
            </div>

        </div>
    )
}

export default Register;