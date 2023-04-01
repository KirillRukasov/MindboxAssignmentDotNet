import React from 'react';
import { useNavigate } from "react-router-dom";
import './HomePage.css';

const HomePage = () => {
    const navigate = useNavigate();

    const handleCircleArea = () => {
        navigate("/circle-area");
    };

    const handleTriangleArea = () => {
        navigate("/triangle-area");
    };

    return (
        <div className="homepage">
            <h1>Расчет площади фигур</h1>
            <div className="button-container">
                <button onClick={handleCircleArea}>Площадь круга</button>
                <button onClick={handleTriangleArea}>Площадь треугольника</button>
            </div>
        </div>
    );
};

export default HomePage;
