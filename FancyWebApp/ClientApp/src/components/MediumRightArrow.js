// @ts-nocheck
import React from 'react'
import {
    makeStyles,
} from "@material-ui/core";

const useStyles = makeStyles({
    wrapper: {
        paddingTop: '20px',
    },
    short: {
        
    },
    long1: {
        transform: 'translateX(30px) scale(0.955)',
        marginLeft: '-30px',
    },
    long2: {
        transform: 'translateX(10px) scale(0.96)'
    }
});

export default function MediumRightArrow() {
    const classes = useStyles();
  return (
    <div>
        <img className={classes.long1} alt="right arrow" src={require('../assets/remove.png')} height="60px" width="80px"></img>
        <img className={classes.long2} alt="right arrow" src={require('../assets/remove.png')} height="60px" width="100px"></img>
        <img className={classes.short} alt="right arrow" src={require('../assets/right-arrow.png')} height="60px" width="80px"></img>
    </div>
   )
}