import { useParams } from "react-router-dom";


const Event = () => {

    const { id } = useParams()

    return(
        <div>
            <h3>{id}</h3>
        </div>
    )
}

export default Event;