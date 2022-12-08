import './checkoutForm.css'

const CheckoutForm = function(){
    return(
        <div className="checkoutForm_main_container">
            <div className="checkoutFrom_subContainer">
                <div className='checkoutForm_title_container'><h5>Ingresa los datos de tu tarjeta</h5></div>

                <div className="form_inputs_container">
                    <form>
                        <input type="text" placeholder="Titular de la tarjeta" className='checkoutForm_input'/>

                        <div className='checkoutForm_card_container'>
                            <input type="text" placeholder="Numero de tarjeta" className='checkoutForm_input_card'/> 
                            <div>-</div>
                            <input type="text" placeholder="LOGO" className='checkoutForm_input_cardLogo'/>
                        </div>

                        <div className='checkoutForm_fecha_container'>
                            <div><p>Fecha de Vencimiento</p></div>
                            <input type="text" placeholder="MM" className='checkoutForm_input_fecha'/>
                            <div>-</div>
                            <input type="text" placeholder="AA" className='checkoutForm_input_fecha'/>
                        </div>

                        <div>
                            <p>Codigo de Seguridad</p>
                            <input type="text" placeholder="CVC" className='checkoutForm_input'/>
                        </div>

                        <div>
                            <button>Cancelar Compra</button>
                            <button>Realizar Pago</button>
                        </div>
                    </form>
                </div>
            </div>

        </div>
    )
}

export default CheckoutForm;