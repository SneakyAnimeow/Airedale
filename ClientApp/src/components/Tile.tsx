import "../custom.css";

function Tile(props: any) {
    return (
        <div className="tile">
            <p>{props.title}</p>
            <p>{props.value}</p>
            <img src={props.img} alt="no image available"/>
        </div>
    );
}

export default Tile;