import React, {useEffect, useState} from 'react';
import {FormControl, FormControlLabel, FormLabel, Radio, RadioGroup} from "@material-ui/core";

function BasicRadio(props) {
    const [value, setValue] = useState('')

    useEffect(() =>{
        console.log(value)
    }, [value]) // scritta cosi viene richiamata ogni volta che nel suo stato il campo 'value' cambia

    return (
        <FormControl>
        <FormLabel>Select Test Value</FormLabel>
        <RadioGroup value={value} onChange={(e) => setValue(e.target.value)}>
            <FormControlLabel value="test1" control={<Radio color="primary"/>} label="TestValue1" />
            <FormControlLabel value="test2" control={<Radio color="primary"/>} label="TestValue2" />
        </RadioGroup>
        </FormControl>
    );
}

export default BasicRadio;