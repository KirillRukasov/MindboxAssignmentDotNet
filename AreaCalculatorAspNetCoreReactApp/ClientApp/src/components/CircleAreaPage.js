import React, { useState } from 'react';
import { useNavigate } from "react-router-dom";
import './CircleAreaPage.css';

const CircleAreaPage = () => {
    const [radius, setRadius] = useState('');
    const [area, setArea] = useState(null);
    const [error, setError] = useState(null);
    const navigate = useNavigate();

    const handleSubmit = async (event) => {
        event.preventDefault();
        setError(null); // Очищаем предыдущие ошибки
        try {
            const response = await fetch(`${process.env.REACT_APP_API_URL}/circle/area?radius=${radius}`);
            if (response.ok) {
                const calculatedArea = await response.json();
                setArea(calculatedArea);
            } else {
                const error = await response.text();
                setError(error);
            }
        } catch (error) {
            console.error('Error fetching circle area:', error);
            setError('Произошла ошибка при расчете площади круга');
        }
    };

    const handleBack = () => {
        navigate("/");
    };

    return (
        <div className="circle-area-page">
            <h1>Площадь круга</h1>
            <form onSubmit={handleSubmit}>
                <div className="input-container">
                    <label htmlFor="radius">Радиус:</label>
                    <input
                        type="number"
                        id="radius"
                        step="0.01"
                        value={radius}
                        onChange={(event) => setRadius(event.target.value)}
                        required
                    />
                </div>
                <div className="button-container">
                    <button onClick={handleSubmit}>Расчет</button>
                    <button onClick={handleBack}>Назад</button>
                </div>
            </form>
            {error && <p className="error">{error}</p>}
            {area !== null && <p>Площадь круга: {area}</p>}
        </div>
    );
};

export default CircleAreaPage;