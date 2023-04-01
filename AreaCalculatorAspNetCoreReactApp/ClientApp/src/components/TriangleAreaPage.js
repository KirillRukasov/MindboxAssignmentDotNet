import React, { useState } from 'react';
import { useNavigate } from "react-router-dom";
import './TriangleAreaPage.css';

const TriangleAreaPage = () => {
    const [sideA, setSideA] = useState('');
    const [sideB, setSideB] = useState('');
    const [sideC, setSideC] = useState('');
    const [area, setArea] = useState(null);
    const [isRight, setIsRight] = useState(null);
    const [error, setError] = useState(null);
    const navigate = useNavigate();

    const handleSubmit = async (event) => {
        event.preventDefault();
        setError(null);
        try {
            const response = await fetch(`${process.env.REACT_APP_API_URL}/triangle/area?sideA=${sideA}&sideB=${sideB}&sideC=${sideC}`);
            if (response.ok) {
                const calculatedArea = await response.json();
                setArea(calculatedArea);

                const isRightResponse = await fetch(`${process.env.REACT_APP_API_URL}/triangle/isRight?sideA=${sideA}&sideB=${sideB}&sideC=${sideC}`);
                if (isRightResponse.ok) {
                    const isRightResult = await isRightResponse.json();
                    setIsRight(isRightResult);
                } else {
                    setError('Ошибка при проверке прямоугольности треугольника');
                }
            } else {
                const error = await response.text();
                setError(error);
            }
        } catch (error) {
            console.error('Error fetching triangle area:', error);
            setError('Произошла ошибка при расчете площади треугольника');
        }
    };

    const handleBack = () => {
        navigate("/");
    };

    return (
        <div className="triangle-area-page">
            <h1>Площадь треугольника</h1>
            <form onSubmit={handleSubmit}>
                <div className="input-container">
                    <div className="input-row">
                        <label htmlFor="sideA">Сторона A:</label>
                        <input
                            type="number"
                            id="sideA"
                            step="0.01"
                            value={sideA}
                            onChange={(event) => setSideA(event.target.value)}
                            required
                        />
                    </div>
                    <div className="input-row">
                        <label htmlFor="sideB">Сторона B:</label>
                        <input
                            type="number"
                            id="sideB"
                            step="0.01"
                            value={sideB}
                            onChange={(event) => setSideB(event.target.value)}
                            required
                        />
                    </div>
                    <div className="input-row">
                        <label htmlFor="sideC">Сторона C:</label>
                        <input
                            type="number"
                            id="sideC"
                            step="0.01"
                            value={sideC}
                            onChange={(event) => setSideC(event.target.value)}
                            required
                        />
                    </div>
                </div>
                <div className="button-container">
                    <button onClick={handleSubmit}>Расчет</button>
                    <button onClick={handleBack}>Назад</button>
                </div>
            </form>
            {error && <p className="error">{error}</p>}
            {area !== null && <p>Площадь треугольника: {area}</p>}
            {isRight !== null && <p>{isRight ? 'Треугольник прямоугольный' : 'Треугольник не прямоугольный'}</p>}
        </div>
    );
};

export default TriangleAreaPage;
