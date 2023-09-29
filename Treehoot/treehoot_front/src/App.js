import logo from "./logo.svg";
import Question from "./components/Question/Question.js";
import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import Home from "./components/Home.js";
import Play from "./components/Play";
import ChooseTopicPage from "./Pages/ChooseTopicPage";
import QuestionPreview from "./Pages/QuestionPreview";

function App() {
  return (
    <Router>
      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/play" element={<Play />} />
        <Route path="/question_preview" element={<QuestionPreview />} />
        <Route path="/question" element={<Question />} />
        <Route path="/choose_topic" element={<ChooseTopicPage />} />
      </Routes>
    </Router>
  );
}

export default App;
