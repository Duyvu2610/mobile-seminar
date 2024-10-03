package matcha.project.be.exception;

import lombok.AccessLevel;
import lombok.Getter;
import lombok.RequiredArgsConstructor;
import lombok.experimental.FieldDefaults;
import matcha.project.be.enums.ItemError;

@FieldDefaults(level = AccessLevel.PRIVATE)
@RequiredArgsConstructor
@Getter
public class ItemException extends RuntimeException {
    ItemError itemError;
    public ItemException(ItemError itemError) {
        super(itemError.getMessage());
        this.itemError = itemError;
    }
}
