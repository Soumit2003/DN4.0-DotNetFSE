import React from "react";

const ListofPlayers = () => {
    const players = [
        { name: "Virat", score: 95 },
        { name: "Rohit", score: 85 },
        { name: "Gill", score: 60 },
        { name: "Iyer", score: 40 },
        { name: "Rahul", score: 73 },
        { name: "Pant", score: 55 },
        { name: "Jadeja", score: 80 },
        { name: "Hardik", score: 67 },
        { name: "Bumrah", score: 30 },
        { name: "Shami", score: 88 },
        { name: "Siraj", score: 45 }
    ];

    const below70 = players.filter(player => player.score < 70);

    return (
        <div>
            <h2>All Players:</h2>
            <ul>
                {players.map((player, index) => (
                    <li key={index}>
                        {player.name} - {player.score}
                    </li>
                ))}
            </ul>
            <h2>Players with Score Below 70:</h2>
            <ul>
                {below70.map((player, index) => (
                    <li key={index}>
                        {player.name} - {player.score}
                    </li>
                ))}
            </ul>
        </div>
    );
};

export default ListofPlayers;
