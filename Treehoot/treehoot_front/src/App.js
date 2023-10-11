import logo from "./logo.svg";
import Question from "./Pages/Question.js";
import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import Home from "./Pages/Home.js";
import Play from "./Pages/Play";
import ChooseTopicPage from "./Pages/ChooseTopicPage";
import QuestionPreview from "./Pages/QuestionPreview";
import Host from "./Pages/Host";
import Join from "./Pages/Join";
import NewGame from "./Pages/NewGame";

function App() {
  return (
    <Router>
      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/play" element={<Play />} />
        <Route path="/question_preview" element={<QuestionPreview />} />
        <Route path="/question" element={<Question />} />
        <Route path="/choose_topic" element={<ChooseTopicPage />} />
        <Route path="/host" element={<Host />} />
        <Route path="/join" element={<Join />} />
        <Route path="/new-game" element={<NewGame />} />
      </Routes>
    </Router>
  );
}

export default App;
