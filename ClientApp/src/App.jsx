import Tile from "./components/Tile.tsx";
import "./custom.css"

function App() {
  return (
      <div className="tiles">
          <Tile value="value" title="title" img="https://us.123rf.com/450wm/aquir/aquir1909/aquir190907813/129839336-example-button-example-rounded-green-sign-example.jpg?ver=6"/>
          <Tile value="value" title="title" img="https://us.123rf.com/450wm/aquir/aquir1909/aquir190907813/129839336-example-button-example-rounded-green-sign-example.jpg?ver=6"/>
      </div>
  );
}

export default App;