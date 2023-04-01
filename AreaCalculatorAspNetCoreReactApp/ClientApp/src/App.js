import React from 'react';
import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import HomePage from "./components/HomePage";
import CircleAreaPage from "./components/CircleAreaPage";
import TriangleAreaPage from "./components/TriangleAreaPage";

function App() {
    return (
        <Router>
            <Routes>
                <Route path="/" element={<HomePage />} index />
                <Route path="/circle-area" element={<CircleAreaPage />} />
                <Route path="/triangle-area" element={<TriangleAreaPage />} />
            </Routes>
        </Router>
    );
}

export default App;

