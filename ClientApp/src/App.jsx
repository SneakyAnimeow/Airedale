import "./custom.css"
import {BrowserRouter as Router, Route, Routes as Switch} from "react-router-dom";
import Login from "./Login.tsx";
import Home from "./Home.tsx";

function App() {
  return (
      <Router>
          <Switch>
              <Route path="/login" element={<Login/>}/>
              <Route path="/" element={<Home/>}/>
          </Switch>
      </Router>
  );
}

export default App;