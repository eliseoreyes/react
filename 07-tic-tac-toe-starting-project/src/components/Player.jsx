import { useState } from "react";

export default function Player({initialName, symbol, isActive, onChangeName}){

    
    const [isEditing, setIsEditing] = useState(false);
    const [playerName, setPlayerName] = useState(initialName);

    function handleEditClick(){
        setIsEditing((editing) => !editing); //Best practice, passes a function, esto es lo mismo que isEditing ? true : false

        if (isEditing) {
            onChangeName(symbol, playerName);
        }
    }

    function handleChange(event){
        setPlayerName(event.target.value); // Get the value
    }

    let editablePlayerName = <span className="player-name">{playerName}</span>;

    if (isEditing){
        editablePlayerName = <input type="text" required value={playerName} onChange={handleChange}/>; // two way binding
    }

    return (
        <li className={isActive ? 'active' : undefined}>
        <span className="player">
          {editablePlayerName}
          <span className="player-simbol">{symbol}</span>
        </span>
        <button onClick={handleEditClick}>{isEditing ? 'Save' : 'Edit'}</button>
      </li>
    );
}
