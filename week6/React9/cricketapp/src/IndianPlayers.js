import React from "react";

const IndianPlayers = () => {
    const oddTeam = ["Virat", "Gill", "Iyer", "Pant", "Bumrah"];
    const evenTeam = ["Rohit", "Rahul", "Jadeja", "Hardik", "Shami", "Siraj"];

    const [p1, p2, p3, ...restOdd] = oddTeam;
    const [e1, e2, e3, ...restEven] = evenTeam;

    const T20players = ["Rohit", "Hardik", "Pant"];
    const RanjiTrophy = ["Jaiswal", "Sarfaraz", "Rahane"];

    const merged = [...T20players, ...RanjiTrophy];

    return (
        <div>
            <h2>Odd Team Players:</h2>
            <ul>
                {[p1, p2, p3, ...restOdd].map((player, index) => (
                    <li key={index}>{player}</li>
                ))}
            </ul>

            <h2>Even Team Players:</h2>
            <ul>
                {[e1, e2, e3, ...restEven].map((player, index) => (
                    <li key={index}>{player}</li>
                ))}
            </ul>

            <h2>Merged T20 and Ranji Trophy Players:</h2>
            <ul>
                {merged.map((player, index) => (
                    <li key={index}>{player}</li>
                ))}
            </ul>
        </div>
    );
};

export default IndianPlayers;
