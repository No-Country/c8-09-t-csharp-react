import "./Reviews.css"

const Reviews = () => {

    return(
        <div className="reviewsContainer">
            <div className="reviews">
                <h2>Reviews</h2>
                <div className="listReviews">
                    <div className="review">
                        <img src="/ratingUser.png" alt="ratingUser" />
                        <h3>Lo pase fantastico! Baile toda la noche con mis amigos.</h3>
                        <div className="userHour">
                            <h5>Sall235</h5>
                            <h5>2 hours ago</h5>
                        </div>
                    </div>
                </div>
            </div>
            {/* <div className="sendReviews">
                <h2>Agrega tu rating y review!</h2>
                <img src="/applyRating.png" alt="applyRating" />
                <h4>Tap to add your rating</h4>
                <input type="text" placeholder="Escribe tu review..."/>
                <button className="buttonSend">Enviar review {">"}</button>
            </div> */}
        </div>
    )
}

export default Reviews;