/////////// Validation form ////////////////

function validate_ChangeBalance(){  
	var accountno=document.myform.accountno.value;
	var balance=document.myform.balance.value;  
	if (accountno==null || accountno=="" || isNaN(accountno)){  
	  alert("Please accountno only numeric value"); 
	  document.myform.accountno.focus() ; 
	  return false;  
	}
	if (balance==null || balance=="" || isNaN(balance)){  
	  alert("Please balance only numeric value"); 
	  document.myform.balance.focus() ; 
	  return false;  
	}

} 

function validate_createaccount(){
	var group=document.myform1.group.value; 
	var name=document.myform1.name.value; 
	var country=document.myform1.country.value; 
	 
	if (group==null || group==""){  
	  alert("group can't be blank"); 
	  document.myform1.group.focus() ; 
	  return false;  
	}
	if (name==null || name==""){  
	  alert("Name can't be blank"); 
	  document.myform1.name.focus() ; 
	  return false;  
	}
	if (country==null || country==""){  
	  alert("Country can't be blank"); 
	  document.myform1.country.focus() ; 
	  return false;  
	}
	if(country[0].toUpperCase() != country[0])
	{
   		alert('First character is upper case.'); 
		document.myform1.country.focus() ; 
	    return false; 
	}
	
}

function validate_modifyaccount(){
	var login=document.myform2.login.value; 
	var group=document.myform2.group.value; 	 
	
	if (login==null || login=="" || isNaN(login)){  
	  alert("Please inter only numeric value"); 
	  document.myform2.login.focus() ; 
	  return false;  
	}
	if (group==null || group==""){  
	  alert("group can't be blank"); 
	  document.myform2.group.focus() ; 
	  return false;  
	}
		
}

function validate_getaccountinfo(){  
	var accountno=document.myform3.accountno.value;  
	if (accountno==null || accountno=="" || isNaN(accountno)){  
	  alert("Please accountno only numeric value"); 
	  document.myform3.accountno.focus() ; 
	  return false;  
	}
} 
function validate_checkpassword(){  
	var accountno=document.myform4.accountno.value;  
	var pass=document.myform4.pass.value;  
	var passw = /^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{5,16}$/; 
	  if (accountno==null || accountno=="" || isNaN(accountno)){  
	   alert("Please accountno only numeric value"); 
       document.myform4.accountno.focus() ; 
	   return false;  
	}
	if (pass==null || pass==""){  
	  alert("Password can't be blank"); 
	  document.myform4.pass.focus() ; 
	  return false;  
	} 
		if(pass!=pass.match(passw))   
		{   
		alert('password between 5 to 16 characters which contain at least one numeric digit, one uppercase and one lowercase letter');
		document.myform4.pass.focus(); 
		return false;  
		} 

} 
function validate_changepassword(){  
	var accountno=document.myform5.accountno.value;  
	var oldpass=document.myform5.oldpass.value; 
	var newpass=document.myform5.newpass.value;
	var passw = /^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{5,16}$/; 
	 
	if (accountno==null || accountno=="" || isNaN(accountno)){  
	  alert("Please accountno only numeric value"); 
	  document.myform5.accountno.focus() ; 
	  return false;  
	}
	if (oldpass==null || oldpass==""){  
	  alert("Password can't be blank"); 
	  document.myform5.oldpass.focus() ; 
	  return false;  
	}
	if (newpass==null || newpass==""){  
	  alert("Password can't be blank"); 
	  document.myform5.newpass.focus() ; 
	  return false;  
	}
	if(newpass!=newpass.match(passw))   
		{   
		alert('password between 5 to 16 characters which contain at least one numeric digit, one uppercase and one lowercase letter');
		document.myform5.newpass.focus(); 
		return false;  
		}  
} 

function validate_getaccountbalance(){  
	var accountno=document.myform6.accountno.value;  
	if (accountno==null || accountno=="" || isNaN(accountno)){  
	  alert("Please accountno only numeric value"); 
	  document.myform6.accountno.focus() ; 
	  return false;  
	}
} 

function validate_changecredit(){  
	var accountno=document.myform7.accountno.value; 
	var credit=document.myform7.credit.value; 
	var expiry=document.myform7.expiry.value; 
	 
	if (accountno==null || accountno=="" || isNaN(accountno)){  
	  alert("Please accountno only numeric value"); 
	  document.myform7.accountno.focus() ; 
	  return false;  
	}
	if (credit==null || credit==""){  
	  alert("credit can't be blank"); 
	  document.myform7.credit.focus() ; 
	  return false;  

	}
	if (expiry==null || expiry==""){  
	  alert("expiry can't be blank"); 
	  document.myform7.expiry.focus() ; 
	  return false;  
	}


} 
 
function validate_getgroup(){  
	var groupid=document.myform8.groupid.value;  
	if (groupid==null || groupid==""){  
	  alert("groupid can't be blank"); 
	  document.myform8.groupid.focus() ; 
	  return false;  
	}
} 

function validate_gethistory(){  
	var accountno=document.myform9.accountno.value;  
	if (accountno==null || accountno=="" || isNaN(accountno)){  
	  alert("Please accountno only numeric value"); 
	  document.myform9.accountno.focus() ; 
	  return false;  
	}
} 

function validate_getmagicinfo(){  
	var groupid=document.myform10.groupid.value;  
	if (groupid==null || groupid==""){  
	  alert("groupid can't be blank"); 
	  document.myform10.groupid.focus() ; 
	  return false;  
	}
} 

function  validate_openorder(){  
	var cmd=document.myform11.cmd.value;
	var orderby=document.myform11.orderby.value;
	var symbol=document.myform11.symbol.value;
	var volume=document.myform11.volume.value;
	var price=document.myform11.price.value;
	var sl=document.myform11.sl.value;
	var tp=document.myform11.tp.value;
	
	  
	if (cmd==null || cmd=="" || isNaN(cmd)){  
	  alert("Please cmd inter only numeric value"); 
	  document.myform11.cmd.focus() ; 
	  return false;  
	}
	if (orderby==null || orderby=="" || isNaN(orderby)){  
	  alert("Please orderby inter only numeric value"); 
	  document.myform11.orderby.focus() ; 
	  return false;  
	}
	if (symbol==null || symbol==""){  
	  alert("symbol can't be blank"); 
	  document.myform11.symbol.focus() ; 
	  return false;  
	}
	if (volume==null || volume=="" || isNaN(volume)){  
	  alert("Please volume inter only numeric value"); 
	  document.myform11.volume.focus() ; 
	  return false;  
	}
	if (price==null || price=="" || isNaN(price)){  
	  alert("Please price inter only numeric value"); 
	  document.myform11.price.focus() ; 
	  return false;  
	}
	if (sl==null || sl=="" || isNaN(sl)){  
	  alert("Please sl inter only numeric value"); 
	  document.myform11.sl.focus() ; 
	  return false;  
	}
	if (tp==null || tp=="" || isNaN(tp)){  
	  alert("Please tp inter only numeric value"); 
	  document.myform11.tp.focus() ; 
	  return false;  
	}
} 

function validate_modifyorder(){  
	var order=document.myform12.order.value;
	var orderby=document.myform12.orderby.value; 
	 
	if (order==null || order=="" || isNaN(order)){  
	  alert("Please order inter only numeric value"); 
	  document.myform12.order.focus() ; 
	  return false;  
	}
	if (orderby==null || orderby=="" || isNaN(orderby)){  
	  alert("Please orderby inter only numeric value"); 
	  document.myform12.orderby.focus() ; 
	  return false;  
	}

} 

function  validate_openpendingorder(){  
	var cmd=document.myform13.cmd.value;
	var orderby=document.myform13.orderby.value;
	var symbol=document.myform13.symbol.value;
	var volume=document.myform13.volume.value;
	var price=document.myform13.price.value;
	var sl=document.myform13.sl.value;
	var tp=document.myform13.tp.value;
	var comment=document.myform13.comment.value;
	
	  
	if (cmd==null || cmd=="" || isNaN(cmd)){  
	  alert("Please cmd inter only numeric value"); 
	  document.myform13.cmd.focus() ; 
	  return false;  
	}
	if (orderby==null || orderby=="" || isNaN(orderby)){  
	  alert("Please orderby inter only numeric value"); 
	  document.myform13.orderby.focus() ; 
	  return false;  
	}
	if (symbol==null || symbol==""){  
	  alert("symbol can't be blank"); 
	  document.myform13.symbol.focus() ; 
	  return false;  
	}
	if (volume==null || volume=="" || isNaN(volume)){  
	  alert("Please volume inter only numeric value"); 
	  document.myform13.volume.focus() ; 
	  return false;  
	}
	if (price==null || price=="" || isNaN(price)){  
	  alert("Please price inter only numeric value"); 
	  document.myform13.price.focus() ; 
	  return false;  
	}
	if (sl==null || sl=="" || isNaN(sl)){  
	  alert("Please sl inter only numeric value"); 
	  document.myform13.sl.focus() ; 
	  return false;  
	}
	if (tp==null || tp=="" || isNaN(tp)){  
	  alert("Please tp inter only numeric value"); 
	  document.myform13.tp.focus() ; 
	  return false;  
	}
	if (comment==null || comment==""){  
	  alert("comment can't be blank"); 
	  document.myform13.comment.focus() ; 
	  return false;  
	}
} 

function validate_modifypendingorder(){  
	var order=document.myform14.order.value;
	var orderby=document.myform14.orderby.value; 
	 
	if (order==null || order=="" || isNaN(order)){  
	  alert("Please order inter only numeric value"); 
	  document.myform14.order.focus() ; 
	  return false;  
	}
	if (orderby==null || orderby=="" || isNaN(orderby)){  
	  alert("Please orderby inter only numeric value"); 
	  document.myform14.orderby.focus() ; 
	  return false;  
	}

} 

function validate_sendemail(){  
	var ToLoginId=document.myform15.ToLoginId.value;
	var SenderloginId=document.myform15.SenderloginId.value; 
	 
	if (ToLoginId==null || ToLoginId=="" || isNaN(ToLoginId)){  
	  alert("Please Login Id inter only numeric value"); 
	  document.myform15.ToLoginId.focus() ; 
	  return false;  
	}
	if (SenderloginId==null || SenderloginId=="" || isNaN(SenderloginId)){  
	  alert("Please Sender login Id inter only numeric value"); 
	  document.myform15.SenderloginId.focus() ; 
	  return false;  
	}

} 

function validate_getleverageofgroup(){  
	var groupid=document.myform16.groupid.value;  
	if (groupid==null || groupid==""){  
	  alert("groupid can't be blank"); 
	  document.myform16.groupid.focus() ; 
	  return false;  
	}
} 
