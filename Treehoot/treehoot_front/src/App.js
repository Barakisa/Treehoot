import logo from "./logo.svg";
import Question from "./components/Question/Question.js";
import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import Home from "./components/Home.js";
import Play from "./components/Play";

function App() {
  return (
    <Router>
      <Routes>
        <Route path="/" element={<Home />} />
        <Route
          path="/question"
          element={
            <div classname="p-2">
              <Question />
            </div>
          }
        />
        <Route path="/play" element={<Play />} />
      </Routes>
    </Router>
  );
}

export default App;
