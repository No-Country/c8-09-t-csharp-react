import "./Footer.css"


const Footer = () => {
    return(
        
<footer className="footer">
        <div className="footer_group_1">
            <div className="box">
            <figure>
                <a className="img-logo" href="#">
                    <img src="/logo-ticketfan-negro.svg" alt="Logosvg" />
                </a>
            </figure>
                </div>
            <div className="box">
                <ul>
                    <li>
                    <img className="ico" src="/correo.svg" alt="Logomail" align="left" />info@ticketfan.com</li>
                    
                    <li>
                    <img className="ico" src="/telefono.svg" align="left"/>+57 313 123 4567
                    </li>
                    
                    <li>
                    <img className="ico" src="/ubicacion.svg" alt="Logoubi" align="left" />calle 40 Sur #45-76,Medellin,Antioquia</li>
                    
                </ul>
                <div className="Social">
                    <a href="#"> 
                    <img src="/instagram.svg" className="socialico" align="left" />
                    </a>
                    <a href="#">
                    <img src="/facebook.svg" className="socialico" align="left" />
                    </a>
                    <a href="#">
                    <img src="/tiktok.svg" className="socialico" align="left" />
                    </a>
            </div>
            </div>
            
            <div className="box">
                <ul className="faq">
                    <li><a href="#">Terminos y condiciones</a></li>
                    <li><a href="#">Politicas de privacidad</a></li>
                    <li><a href="#">Preguntas frecuentes</a></li>
                    <li><a href="#">Devolucion de compra</a></li>
                </ul>
                
            </div>
            
        </div>
        <div className="line"><hr/></div>
        
        
</footer>


    )
}

export default Footer;