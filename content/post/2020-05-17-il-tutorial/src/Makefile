IL := ilasm /nologo /quiet
ILDASM := ildasm

%.il: %.exe
	$(ILDASM) $< /OUT=disasm-$@ /TEXT
		
%.dll: %.il
	$(IL) /debug /dll $< /OUT=$@

%.exe: %.il
	$(IL) /debug /OUT=$@ $<
	./$@
	
clean:
	rm *.dll
	rm *.exe
	
.PHONY: $(ALL) default clean